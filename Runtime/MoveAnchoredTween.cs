using DG.Tweening;
using UnityEngine;

namespace Tityx.Tweens
{
    public class MoveAnchoredTween : AbstractTween
    {
        [field: Space]
        [field: SerializeField] public Vector2 Start;
        [field: SerializeField] public Vector2 End;

        private RectTransform rect => Target as RectTransform;

        public void SetValue(Vector2 val, bool isStart)
        {
            if (isStart) Start = val;
            else End = val;
        }

        protected override Tween GetTweenLogic(bool straight)
        {
            return rect.DOAnchorPos(straight ? End : Start, Settings.Duration);
        }

        public override void ResetValue(bool straight = true)
        {
            if (straight)
            {
                rect.anchoredPosition = Start;
            }
            else
            {
                rect.anchoredPosition = End;
            }
        }
    }
}