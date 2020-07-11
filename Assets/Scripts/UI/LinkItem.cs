using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SharedYoutubePlayer.Player;

namespace SharedYoutubePlayer.UI
{
    public class LinkItem : MonoBehaviour
    {
        public Player.YoutubePlayer player {get;set;}
        public Link link {get;set;}

        [SerializeField]
        UnityEngine.UI.Text _title;

        public LinkItem(Player.YoutubePlayer player, Link link)
        {
            this.link = link;
            this.player = player;
        } 

        public void SetText(string text)
        {
            _title.text = text;
        }

        public async void Play()
        {
            await player.PlayVideoAsync(this);
        }

        public void Remove()
        {
            Destroy(gameObject);
        }
    }
}

