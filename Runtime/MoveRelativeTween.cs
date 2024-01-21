using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tityx.Tweens
{
    public class MoveRelativeTween : AbstractTween
    {
        [field: Space]
        [field: SerializeField] public bool UseLocalSpace { get; private set; } = true;
        [field: SerializeField] public Vector3 Offset { get; private set; }

        public void SetValue(Vector3 val)
        {
            Offset = val;
        }

        protected override Tween GetTweenLogic(bool straight)
        {
            if (UseLocalSpace)
                return Target
                    .DOLocalMove(straight ? Offset : -Offset, Settings.Duration)
                    .SetRelative();
            else
                return Target
                    .DOMove(straight ? Offset : -Offset, Settings.Duration)
                    .SetRelative();
        }

        public override void ResetValue(bool straight = true) { }
    }
}