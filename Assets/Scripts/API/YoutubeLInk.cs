using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SharedYoutubePlayer.Player;
using Proyecto26;

namespace SharedYoutubePlayer.API
{
    public class YoutubeLink
    {
        private readonly string basePath = "https://codewear-musicplayer.herokuapp.com";
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
        }

        public void GetList(System.Action<Link> success, System.Action fail=null)
        {
            if(cached == null)
                cached = new List<Link>();

            RestClient.Get<VideoListResponse>(basePath + "/videolist").Then(res => {
                foreach(var item in res.data)
                    success?.Invoke(item);

                cached = new List<Link>(res.data);
		    }).Catch(err => Debug.LogError($"Error {err.Message}"));
        }

        public void AddLink(Link link, System.Action<Link> success, System.Action fail=null)
        {
            if(cached == null)
                cached = new List<Link>();

            var postListRequest = new RequestHelper {
                Uri = basePath + "/video",
                Body = new VideoAddRequest {
                    videoKey = link.key,
                    videoName = link.name
                },
                EnableDebug = true
            };

            RestClient.Post<LoginResponse>(postListRequest).Then(res => {
                if(res.status == "201")
                {
                    success?.Invoke(link);
                    cached.Add(link);
                }else
                {
                    fail?.Invoke();
                }
                
		    }).Catch(err => {
                fail?.Invoke();
                Debug.LogError($"Error, {err.Message})");
            });
        }
    }

}
