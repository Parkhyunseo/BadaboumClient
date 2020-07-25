using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace SharedYoutubePlayer.API
{
    public class PopUp : MonoBehaviour
    {
        [SerializeField]
        Text _text;

        public void Show(string text)
        {
            _text.text = text;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}

