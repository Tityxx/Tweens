using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Tityx.Tweens
{
    public class TransformTween : AbstractTween
    {
        [field: Space]
        [field: SerializeField] public Transform Start { get; private set; }
        [field: SerializeField] public Transform End { get; private set; }

        private Tween _rotationTween;
        private Tween _scaleTween;

        public void SetValue(Transform val, bool isStart)
        {
            if (isStart) Start = val;
            else End = val;
        }

        public override void Stop()
        {
            base.Stop();
            if (_rotationTween != null)
            {
                _rotationTween.Rewind();
            }
            if (_scaleTween != null)
            {
                _scaleTween.Rewind();
            }
        }

        public override void Kill()
        {
            base.Kill();
            if (_rotationTween != null)
            {
                _rotationTween.Kill();
            }
            if (_scaleTween != null)
            {
                _scaleTween.Kill();
            }
        }

        public override void Pause()
        {
            base.Pause();
            if (_rotationTween != null)
            {
                _rotationTween.Pause();
            }
            if (_scaleTween != null)
            {
                _scaleTween.Pause();
            }
        }

        protected override void OnCompleted()
        {
            _rotationTween = null;
            _scaleTween = null;
            base.OnCompleted();
        }

        public override void ResetValue(bool straight = true)
        {
            if (straight)
            {
                Target.position = Start.position;
                Target.rotation = Start.rotation;
                Target.localScale = Start.localScale;
            }
            else
            {
                Target.position = End.position;
                Target.rotation = End.rotation;
                Target.localScale = End.localScale;
            }
        }

        protected override Tween GetTweenLogic(bool straight)
        {
            return Target.DOMove(straight ? End.position : Start.position, Settings.Duration);
        }

        protected override void ExecuteInner(bool straight)
        {
            _rotationTween = Target
                .DORotate(straight ? End.eulerAngles : Start.eulerAngles, Settings.Duration, RotateMode.Fast)
                .SetSettings(Settings);
            _scaleTween = Target
                .DOScale(straight ? End.localScale : Start.localScale, Settings.Duration)
                .SetSettings(Settings);
        }
    }
}