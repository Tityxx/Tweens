using DG.Tweening;
using UnityEngine;

namespace Tityx.Tweens
{
    public class PunchRotationTween : AbstractTween
    {
        [field: Space]
        [field: SerializeField] public int Vibrato { get; private set; }
        [field: SerializeField] public float Elasticity { get; private set; }
        [field: SerializeField] public Vector3 Value { get; private set; }

        private Vector3 _startRotation;

        protected override void Awake()
        {
            _startRotation = Target.localEulerAngles;
            base.Awake();
        }

        public void SetValue(Vector3 val)
        {
            Value = val;
        }

        protected override Tween GetTweenLogic(bool straight)
        {
            return Target.DOPunchRotation(Value, Settings.Duration, Vibrato, Elasticity);
        }

        public override void ResetValue(bool straight = true)
        {
            Target.localEulerAngles = _startRotation;
        }
    }
}