using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SharedYoutubePlayer.API;

namespace SharedYoutubePlayer.UI
{
    public class RefreshButton : MonoBehaviour
    {
        [SerializeField]
        LinkList list;

        public void Run()
        {
            list.UpdateList();
        }
    }
}

