using UnityEngine;
using DG.Tweening;

namespace Tityx.Tweens
{
    public class QuaternionRotationTween : AbstractTween
    {
        [field: Space]
        [field: SerializeField] public bool UseLocalSpace { get; private set; } = true;
        [field: SerializeField] public Vector3 Start { get; private set; }
        [field: SerializeField] public Vector3 End { get; private set; }

        public void SetValue(Vector3 val, bool isStart)
        {
            if (isStart) Start = val;
            else End = val;
        }

        protected override Tween GetTweenLogic(bool straight)
        {
            var endValue = Quaternion.Euler(straight ? End : Start);
            if (UseLocalSpace)
            {
                return Target.DOLocalRotateQuaternion(endValue, Settings.Duration);
            }
            else
            {
                return Target.DORotateQuaternion(endValue, Settings.Duration);
            }
        }

        public override void ResetValue(bool straight = true)
        {
            if (straight)
            {
                Target.localEulerAngles = Start;
            }
            else
            {
                Target.localEulerAngles = End;
            }
        }
    }
}