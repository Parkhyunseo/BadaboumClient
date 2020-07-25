using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using SharedYoutubePlayer.API;

namespace SharedYoutubePlayer.UI
{
    public class AddButton : MonoBehaviour
    {
        [SerializeField]
        Text _url;
        [SerializeField]
        Text _title;
        [SerializeField]
        LinkList _linkList;

        public void Run()
        {
            API.YoutubeLink.instance.AddLink(new Player.Link{
                key = _url.text,
                name = _title.text    
            }, _linkList.CreateItem);
        }
    }
}


