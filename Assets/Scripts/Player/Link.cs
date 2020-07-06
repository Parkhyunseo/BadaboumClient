using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YoutubePlayer.Player
{
    public class Link
    {
        public string URL {get; private set;}
        public Link(string URL)
        {
            this.URL = URL;
        }
    }
}