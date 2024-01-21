using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Tityx.Tweens
{
    public class PathTween : AbstractTween
    {
        [field: Space]
        [field: SerializeField] public PathType PathType;
        [field: SerializeField] public PathMode PathMode;
        [field: SerializeField] public List<Transform> Path;

        [Header("Debug")]
        [SerializeField] private float _pointRadius = 0.05f;

        private Vector3 _startPosition;
        private Quaternion _startRotation;
        private List<Vector3> _pathPos = new List<Vector3>();
        private List<Vector3> _pathPosReverse = new List<Vector3>();

        protected override void Awake()
        {
            _startPosition = Target.position;
            _startRotation = Target.rotation;

            foreach (Transform t in Path)
            {
                _pathPos.Add(t.position);
                _pathPosReverse.Add(t.position);
            }
            _pathPosReverse.Reverse();

            base.Awake();
        }

        public void SetValue(List<Vector3> val, bool isStart)
        {
            _pathPos.Clear();
            _pathPos.AddRange(val);
            _pathPosReverse.Clear();
            _pathPosReverse.AddRange(val);

            if (isStart) _pathPosReverse.Reverse();
            else _pathPos.Reverse();
        }

        protected override Tween GetTweenLogic(bool straight)
        {
            return Target.DOPath(straight ? _pathPos.ToArray() : _pathPosReverse.ToArray(), Settings.Duration, PathType, PathMode);
        }

        public override void ResetValue(bool straight = true)
        {
            Target.position = _startPosition;
            Target.rotation = _startRotation;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            foreach (var t in Path)
            {
                Gizmos.DrawSphere(t.position, _pointRadius);
            }
        }
    }
}