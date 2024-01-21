using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tityx.Tweens
{
    public class PunchPositionTween : AbstractTween
    {
        [field: Space]
        [field: SerializeField] public int Vibrato { get; private set; }
        [field: SerializeField] public float Elasticity { get; private set; }
        [field: SerializeField] public Vector3 Value { get; private set; }

        private Vector3 _startPosition;

        protected override void Awake()
        {
            _startPosition = Target.localPosition;
            base.Awake();
        }

        public void SetValue(Vector3 val)
        {
            Value = val;
        }

        protected override Tween GetTweenLogic(bool straight)
        {
            return Target.DOPunchPosition(Value, Settings.Duration, Vibrato, Elasticity);
        }

        public override void ResetValue(bool straight = true)
        {
            Target.localPosition = _startPosition;
        }
    }
}