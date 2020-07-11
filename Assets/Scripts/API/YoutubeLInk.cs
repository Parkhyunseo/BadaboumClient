using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SharedYoutubePlayer.Player;

namespace SharedYoutubePlayer.API
{
    public class YoutubeLink
    {
        List<Link> cached;
        LinkFactory _linkFactory = new LinkFactory();

        System.Tuple<string, string>[] links = new System.Tuple<string, string>[]
        {
            new System.Tuple<string, string>("https://www.youtube.com/watch?v=otgkJ_4yVro", "Piano2"),
            new System.Tuple<string, string>("https://www.youtube.com/watch?v=MPzbTJN5wVc", "Mash Up"),
            new System.Tuple<string, string>("https://www.youtube.com/watch?v=HlN2BXNJzxA", "Closer"),
            new System.Tuple<string, string>("https://www.youtube.com/watch?v=XDbW5bXrm7I", "Song"),
            new System.Tuple<string, string>("https://www.youtube.com/watch?v=PUgBFJbeieQ", "Piano"),
            new System.Tuple<string, string>("https://www.youtube.com/watch?v=PUgBFJbeieQ", "Piano"),
            new System.Tuple<string, string>("https://www.youtube.com/watch?v=PUgBFJbeieQ", "Piano"),
            new System.Tuple<string, string>("https://www.youtube.com/watch?v=PUgBFJbeieQ", "Piano"),
            new System.Tuple<string, string>("https://www.youtube.com/watch?v=PUgBFJbeieQ", "Piano"),
            new System.Tuple<string, string>("https://www.youtube.com/watch?v=PUgBFJbeieQ", "Piano"),
            new System.Tuple<string, string>("https://www.youtube.com/watch?v=PUgBFJbeieQ", "Piano"),
            new System.Tuple<string, string>("https://www.youtube.com/watch?v=PUgBFJbeieQ", "Piano"),
            new System.Tuple<string, string>("https://www.youtube.com/watch?v=PUgBFJbeieQ", "Piano"),
            new System.Tuple<string, string>("https://www.youtube.com/watch?v=PUgBFJbeieQ", "Piano"),
            new System.Tuple<string, string>("https://www.youtube.com/watch?v=PUgBFJbeieQ", "Piano"),
            new System.Tuple<string, string>("https://www.youtube.com/watch?v=PUgBFJbeieQ", "Piano"),
            new System.Tuple<string, string>("https://www.youtube.com/watch?v=PUgBFJbeieQ", "Piano"),
            new System.Tuple<string, string>("https://www.youtube.com/watch?v=PUgBFJbeieQ", "Piano"),
            new System.Tuple<string, string>("https://www.youtube.com/watch?v=PUgBFJbeieQ", "Piano"),
        };

        static YoutubeLink _instance;

        public static YoutubeLink instance
        {
            get
            {
                if(_instance == null)
                    _instance = new YoutubeLink();

                return _instance;
            }
        }

        private YoutubeLink()
        {
            cached = new List<Link>();
            foreach(var url in links)
                cached.Add(_linkFactory.GetLink(url.Item1, url.Item2));
        }

        public List<Link> GetList()
        {
            if(cached == null)
                cached = new List<Link>();

            return cached;
        }
    }

}
