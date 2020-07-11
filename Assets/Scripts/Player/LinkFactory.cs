using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SharedYoutubePlayer.Player
{
    public class LinkFactory
    {
        public Link GetLink(string url, string title)
        {
            return new Link(url, title);
        }
    }
}
