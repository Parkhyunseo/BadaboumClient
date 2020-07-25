using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SharedYoutubePlayer.UI
{
    public class CancelButton : MonoBehaviour
    {
        [SerializeField]
        GameObject _loginPanel;
        [SerializeField]
        GameObject _registerPanel;
        public void Cancel()
        {
            _loginPanel.SetActive(true);
            _registerPanel.SetActive(false);
        }
    }
}
