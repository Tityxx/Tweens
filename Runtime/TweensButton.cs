using System.Collections;
using System.Collections.Generic;
using Tityx.Utilities;
using UnityEngine;

namespace Tityx.Tweens
{
    using Utilities.UI;

    public class TweensButton : AbstractButton
    {
        [SerializeField] private bool _straight;
        [SerializeField] private List<GameObject> _enableObjects;
        [SerializeField] private List<GameObject> _disableObjects;
        [SerializeField] private List<AbstractTween> _tweens;

        public override void OnButtonClick()
        {
            _enableObjects.SetActive(true);
            _disableObjects.SetActive(false);

            foreach (var t in _tweens)
            {
                t.Execute(_straight);
            }
        }
    }
}