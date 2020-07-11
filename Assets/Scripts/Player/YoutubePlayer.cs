using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Video;
using YoutubeExplode;
using YoutubeExplode.Models.ClosedCaptions;
using YoutubeExplode.Models.MediaStreams;
using YoutubePlayers;

using SharedYoutubePlayer.UI;

namespace SharedYoutubePlayer.Player
{
    [RequireComponent(typeof(VideoPlayer))]
    public class YoutubePlayer : MonoBehaviour
    {
        [SerializeField]
        LinkList list;
        /// <summary>
        /// Youtube url (e.g. https://www.youtube.com/watch?v=VIDEO_ID)
        /// </summary>
        public string youtubeUrl;

        /// <summary>
        /// VideoStartingDelegate 
        /// </summary>
        /// <param name="url">Youtube url (e.g. https://www.youtube.com/watch?v=VIDEO_ID)</param>
        public delegate void VideoStartingDelegate(string url);

        /// <summary>
        /// Event fired when a youtube video is starting
        /// Useful to start downloading captions, etc.
        /// </summary>
        public event VideoStartingDelegate YoutubeVideoStarting;

        private VideoPlayer videoPlayer;
        private YoutubeClient youtubeClient;

        LinkItem _current;

        private void Awake()
        {
            youtubeClient = new YoutubeClient();
            videoPlayer = GetComponent<VideoPlayer>();

            videoPlayer.loopPointReached += (e) =>
            {
                list.PlayNext(_current);
            };
        }

        private async void OnEnable()
        {
            if (videoPlayer.playOnAwake)
                await PlayVideoAsync();
        }

        /// <summary>
        /// Play the youtube video in the attached Video Player component.
        /// </summary>
        /// <param name="videoUrl">Youtube url (e.g. https://www.youtube.com/watch?v=VIDEO_ID)</param>
        /// <returns>A Task to await</returns>
        /// <exception cref="NotSupportedException">When the youtube url doesn't contain any supported streams</exception>
        public async Task PlayVideoAsync(LinkItem video)
        {
            _current = video;
            await PlayVideoAsync(_current.link.URL);
        }
        
        public async Task PlayVideoAsync(string videoUrl = null)
        {
            try
            {
                //videoUrl = videoUrl ?? youtubeUrl;
                var videoId = GetVideoId(videoUrl);
                Debug.Log(videoId);
                var streamInfoSet = await youtubeClient.GetVideoMediaStreamInfosAsync(videoId);
                var streamInfo = streamInfoSet.WithHighestVideoQualitySupported();
                if (streamInfo == null)
                    throw new NotSupportedException($"No supported streams in youtube video '{videoId}'");

                videoPlayer.source = VideoSource.Url;

                //Resetting the same url restarts the video...
                if (videoPlayer.url != streamInfo.Url)
                    videoPlayer.url = streamInfo.Url;

                videoPlayer.Play();
                youtubeUrl = videoUrl;
                YoutubeVideoStarting?.Invoke(youtubeUrl);
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }
        public string GetVideoId(string videoUrl = null)
        {
            if (!YoutubeClient.TryParseVideoId(videoUrl, out var videoId))
                throw new ArgumentException("Invalid youtube url", nameof(videoUrl));

            return videoId;
        }
    }

}
