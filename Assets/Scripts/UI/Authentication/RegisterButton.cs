using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SharedYoutubePlayer.API;

namespace SharedYoutubePlayer.UI
{
    public class RegisterButton : MonoBehaviour
    {
        [SerializeField]
        Text _id;
        [SerializeField]
        Text _password;
        [SerializeField]
        PopUp _popUp;
        [SerializeField]
        GameObject _registerPanel;
        [SerializeField]
        GameObject _loginPanel;

        public void TryRegister()
        {
            Auth.instance.Register(_id.text, _password.text, 
                () => {
                    _popUp.Show("회원가입 성공");
                    _loginPanel.SetActive(true);
                    _registerPanel.SetActive(false);
                },
                () => {
                    _popUp.Show("회원가입 실패");
                });    
        }
    }

}
