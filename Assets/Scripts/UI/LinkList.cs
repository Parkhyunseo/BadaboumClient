using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SharedYoutubePlayer.Player;

namespace SharedYoutubePlayer.UI
{
    public class LinkList : MonoBehaviour
    {
        [SerializeField]
        Player.YoutubePlayer _player;

        [SerializeField]
        LinkItem _itemPrefab;

        List<LinkItem> _list;

        void Start()
        {
            _list = new List<LinkItem>();
            UpdateList();
        }

        void CreateItem(Link link)
        {
            var item = Instantiate(_itemPrefab);
            item.transform.SetParent(transform);
            item.player = _player;
            item.link = link;
            item.SetText(link.title);

            _list.Add(item);
        }

        public void RemoveItem(LinkItem item)
        {
            _list.Remove(item);
            Destroy(item);
        }

        public void UpdateList()
        {
            Clear();
            foreach(var link in API.YoutubeLink.instance.GetList())
                CreateItem(link);
        }

        public async void PlayNext(LinkItem current)
        {
            if(_list.Count <= 0)
                return;

            LinkItem next;

            if(!_list.Contains(current))
                next = _list[0];
            else
            {
                var index  = _list.IndexOf(current);
                next = _list[0];

                if(_list.IndexOf(current) != _list.Count-1)
                    next = _list[index+1];
            }
            
            await _player.PlayVideoAsync(next);
        }

        public void Clear()
        {
            foreach(Transform item in transform)
                Destroy(item.gameObject);
        }
    }
}
