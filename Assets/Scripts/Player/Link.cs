using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SharedYoutubePlayer.Player
{
    public class Link
    {
        public string URL {get; private set;}
        public string title {get; private set;}
        public Link(string URL, string title)
        {
            this.URL = URL;
            this.title = title;
        }
    }
}