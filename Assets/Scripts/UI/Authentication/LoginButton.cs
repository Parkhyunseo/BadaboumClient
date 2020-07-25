using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using SharedYoutubePlayer.API;

namespace SharedYoutubePlayer.UI
{
    public class LoginButton : MonoBehaviour
    {
        [SerializeField]
        Text _id;
        [SerializeField]
        Text _password;
        [SerializeField]
        PopUp _popUp;
        public void TryLogin()
        {
            Auth.instance.Login(_id.text, _password.text, 
                () => SceneManager.LoadScene("Main"), 
                () => _popUp.Show("로그인 실패"));
        }
    }
}

