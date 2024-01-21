using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Tityx.Tweens
{
    public class AlphaTween : AbstractTween
    {
        [field: Space]
        [field: SerializeField] public float Start { get; private set; }
        [field: SerializeField] public float End { get; private set; }

        private Graphic Graphic
        {
            get
            {
                if (_graphic == null)
                {
                    _graphic = Target.GetComponent<Graphic>();
                }
                return _graphic;
            }
        }

        private Graphic _graphic;

        public void SetValue(float val, bool isStart)
        {
            if (isStart) Start = val;
            else End = val;
        }

        protected override Tween GetTweenLogic(bool straight)
        {
            return Graphic.DOFade(straight ? End : Start, Settings.Duration);
        }

        public override void ResetValue(bool straight = true)
        {
            if (straight)
            {
                SetAlpha(Start);
            }
            else
            {
                SetAlpha(End);
            }
        }

        private void SetAlpha(float value)
        {
            Color c = Graphic.color;
            c.a = value;
            Graphic.color = c;
        }
    }
}