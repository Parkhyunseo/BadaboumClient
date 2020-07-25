using System.Collections.Generic;
using SharedYoutubePlayer.Player;

namespace SharedYoutubePlayer
{
    [System.Serializable]
    public class VideoListResponse
    {
        public string status;
        public List<Link> data;
    }
}
