using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Tityx.Tweens
{
    /// <summary>
    /// Source: https://gitlab.com/syhodyb99/tools-and-mechanics
    /// Абстрактный класс для твинов
    /// </summary>
    public abstract class AbstractTween : MonoBehaviour
    {
        public UnityEvent onStart;
        public UnityEvent onComplete;

        public bool IsCompleted { get; protected set; } = true;
        public Transform Target
        {
            get
            {
                return _target == null ? transform : _target;
            }
        }

        [field: SerializeField] public TweenSettings Settings { get; protected set; }
        [SerializeField] protected Transform _target;

        protected Tween _currTween;

        protected virtual void Awake()
        {
            if (Settings.OverrideValueOnAwake)
            {
                ResetValue();
            }
        }

        protected virtual void OnEnable()
        {
            if (Settings.ExecuteOnEnable)
            {
                Execute();
            }
        }

        protected virtual void OnDestroy()
        {
            Kill();
        }

        public virtual void Execute(bool straight = true)
        {
            if (!CanExecute()) return;

            Stop();
            IsCompleted = false;

            if (Settings.OverrideValueOnExecute)
            {
                ResetValue(straight);
            }

            onStart.Invoke();
            _currTween = GetTweenLogic(straight)
                .SetSettings(Settings, OnCompleted);
            ExecuteInner(straight);
        }

        public virtual void Stop()
        {
            if (_currTween != null)
            {
                _currTween.Rewind();
            }
        }

        public virtual void Kill()
        {
            if (_currTween != null)
            {
                _currTween.Kill();
            }
        }

        public virtual void Pause()
        {
            if (_currTween != null)
            {
                _currTween.Pause();
            }
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public abstract void ResetValue(bool straight = true);
        protected abstract Tween GetTweenLogic(bool straight);

        protected virtual void OnCompleted()
        {
            _currTween = null;
            IsCompleted = true;
            onComplete.Invoke();
        }

        protected virtual bool CanExecute()
        {
            if (_currTween != null)
            {
                if (_currTween.IsPlaying() && !Settings.CanBeInterrupted) return false;
            }
            return true;
        }

        protected virtual void ExecuteInner(bool straight) { }

        [ContextMenu("Execute")]
        private void MenuExecute()
        {
            Execute();
        }

        [ContextMenu("Reverse Execute")]
        private void MenuReverseExecute()
        {
            Execute(false);
        }
    }
}