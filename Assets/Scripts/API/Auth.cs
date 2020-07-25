using Models;
using Proyecto26;
using UnityEngine;

namespace SharedYoutubePlayer.API
{
    public class Auth
    {
        private readonly string basePath = "https://codewear-musicplayer.herokuapp.com";

        static Auth _instance;

        public static Auth instance
        {
            get
            {
                if(_instance == null)
                    _instance = new Auth();

                return _instance;
            }
        }

        public void Login(string id, string password, System.Action success, System.Action fail=null)
        {
            // RestClient.Get(basePath + "/videolist").Then(res => {
            //     success?.Invoke();
            //     Debug.Log(res.Text);
		    // }).Catch(err => {
            //     fail?.Invoke();
            //     Debug.LogError(err.ToString());
            // });

		    var loginRequest = new RequestHelper {
                Uri = basePath + "/signin",
                Body = new Users.User {
                    id = id,
                    password = password
                },
                EnableDebug = true
            };

            RestClient.Post<LoginResponse>(loginRequest)
            .Then(res => {
                if(res.status == "200")
                {
                    success?.Invoke();
                }else
                {
                    fail?.Invoke();
                }
                // And later we can clear the default query string params for all requests
                RestClient.ClearDefaultParams();
                
                Debug.Log($"Success, {JsonUtility.ToJson(res, true)})");
            })
            .Catch(err => {
                fail?.Invoke();
                Debug.LogError($"Error, {err.Message})");
            });
        }

        public bool Logout()
        {
            return true;
        }

        public void Register(string id, string password, System.Action success, System.Action fail=null)
        {
            var loginRequest = new RequestHelper {
                Uri = basePath + "/user",
                Body = new Users.User {
                    id = id,
                    password = password
                },
                EnableDebug = true
            };

            RestClient.Post<LoginResponse>(loginRequest)
            .Then(res => {
                if(res.status == "201")
                {
                    success?.Invoke();
                }else
                {
                    fail?.Invoke();
                }
                // And later we can clear the default query string params for all requests
                RestClient.ClearDefaultParams();
                
                Debug.Log($"Success, {JsonUtility.ToJson(res, true)})");
            })
            .Catch(err => {
                fail?.Invoke();
                Debug.LogError($"Error, {err.Message})");
            });
        }
    }
}

