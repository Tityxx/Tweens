using DG.Tweening;

namespace Tityx.Tweens
{
    [System.Serializable]
    public struct TweenSettings
    {
        public UpdateType UpdateType;
        public bool IgnoreTimeScale;
        public bool CanBeInterrupted;
        public bool ExecuteOnEnable;
        public bool OverrideValueOnAwake;
        public bool OverrideValueOnExecute;
        public float Duration;
        public float Delay;
        public Ease EaseType;
        public LoopType LoopType;
        public int LoopCount;
    }
}