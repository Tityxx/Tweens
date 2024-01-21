using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tityx.Tweens
{
    public static class TweenExtensions
    {

        public static Tween SetSettings(this Tween tween, TweenSettings Settings, Action completeAction = null)
        {
            return tween
                .SetEase(Settings.EaseType)
                .SetLoops(Settings.LoopCount, Settings.LoopType)
                .SetUpdate(Settings.UpdateType, Settings.IgnoreTimeScale)
                .SetDelay(Settings.Delay)
                .OnComplete(() => { if (completeAction != null) completeAction(); });
        }
    }
}