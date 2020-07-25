using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SharedYoutubePlayer.Player
{
    [System.Serializable]
    public class Link
    {
        public string id;
        public string key;
        public string name;
        public string URL => $"https://www.youtube.com/watch?v={key}"; 
    }
}