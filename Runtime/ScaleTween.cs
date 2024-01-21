using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Tityx.Tweens
{
    public class ScaleTween : AbstractTween
    {
        [field: Space]
        [field: SerializeField] public Vector3 Start { get; private set; }
        [field: SerializeField] public Vector3 End { get; private set; }

        public void SetValue(Vector3 val, bool isStart)
        {
            if (isStart) Start = val;
            else End = val;
        }

        protected override Tween GetTweenLogic(bool straight)
        {
            return Target.DOScale(straight ? End : Start, Settings.Duration);
        }

        public override void ResetValue(bool straight = true)
        {
            if (straight)
            {
                Target.localScale = Start;
            }
            else
            {
                Target.localScale = End;
            }
        }
    }
}