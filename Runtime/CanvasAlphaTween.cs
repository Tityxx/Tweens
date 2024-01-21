using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Tityx.Tweens
{
    public class CanvasAlphaTween : AbstractTween
    {
        [field: Space]
        [field: SerializeField] public float Start { get; private set; }
        [field: SerializeField] public float End { get; private set; }

        private CanvasGroup Group
        {
            get
            {
                if (_group == null)
                {
                    _group = Target.GetComponent<CanvasGroup>();
                }
                return _group;
            }
        }

        private CanvasGroup _group;

        public void SetValue(float val, bool isStart)
        {
            if (isStart) Start = val;
            else End = val;
        }

        protected override Tween GetTweenLogic(bool straight)
        {
            return Group.DOFade(straight ? End : Start, Settings.Duration);
        }

        public override void ResetValue(bool straight = true)
        {
            Group.alpha = straight ? Start : End;
        }
    }
}