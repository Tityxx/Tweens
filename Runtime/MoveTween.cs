using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Tityx.Tweens
{
    public class MoveTween : AbstractTween
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
            Vector3 endPosition = straight ? End : Start;
            if (UseLocalSpace)
                return Target.DOLocalMove(endPosition, Settings.Duration);
            else
                return Target.DOMove(endPosition, Settings.Duration);
        }

        public override void ResetValue(bool straight = true)
        {
            if (UseLocalSpace)
            {
                Target.localPosition = straight ? Start : End;
            }
            else
            {
                Target.position = straight ? Start : End;
            }
        }
    }
}