using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SharedYoutubePlayer.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        GameObject _loginPanel;
        [SerializeField]
        GameObject _registerPanel;

        public void OpenLoginPanel()
        {
            _loginPanel.SetActive(true);
            _registerPanel.SetActive(false);
        }

        public void OpenRegisterPanel()
        {
            _registerPanel.SetActive(true);
            _loginPanel.SetActive(false);
        }
    }

}
