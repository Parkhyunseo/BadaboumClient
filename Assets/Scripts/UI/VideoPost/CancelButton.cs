using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SharedYoutubePlayer.UI.VideoPost
{
    public class CancelButton : MonoBehaviour
    {
        [SerializeField]
        GameObject _panel;

        public void Run()
        {
            _panel.SetActive(false);
        }
    }
}
