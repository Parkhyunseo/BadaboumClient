using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YoutubePlayer.Users
{
    public class User
    {
        public string id {get; private set;}
        public string password {get; private set;}

        public User(string id, string password)
        {
            this.id = id;
            this.password = password;
        }
    }

}
