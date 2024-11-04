namespace Singleton.Assignment1
{
    using System;
    using System.Collections.Generic;
    using System.Net.Sockets;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class CellHandler : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        HorizontalLayoutGroup _parent;
        [SerializeField] GraphicRaycaster _graphicRaycaster;

        [SerializeField] Canvas _canvas;

        bool _isOnSocket = false;
        Placeable _currentSocket;

        void Start()
        {
            _parent = transform.parent.GetComponent<HorizontalLayoutGroup>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position += (Vector3.right * eventData.delta.x) + (Vector3.up * eventData.delta.y);

            List<RaycastResult> results = new List<RaycastResult>();
            _graphicRaycaster.Raycast(eventData, results);

            if (_currentSocket != null) { 
                _currentSocket.ResetGraphics();
            }

            if (results.Count > 0)
            {
                Placeable socket = null;

                var rr = results.Find((m) =>
                {
                    if(m.gameObject.TryGetComponent<Placeable>(out Placeable s))
                    {
                        Debug.Log("found: " + m.gameObject.name);
                        socket = s;
                        return true;
                    }
                    return false;
                });

                if (socket != null) {
                    //if(socket._type == 1)
                    socket.ChangeColor(socket._highlightColor);
                    _currentSocket = socket;
                    _isOnSocket = true;
                }
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            transform.parent = _parent.transform;
            _parent.SetLayoutHorizontal();

            if (_isOnSocket)
            {
                Place();
            }
            else
            {
                _isOnSocket = false;
                //if (_currentSocket._type == 1)
                _currentSocket?.ResetGraphics();
                _currentSocket = null;
            }
        }

        private void Place()
        {
            //if (_currentSocket._type == 1)
            _currentSocket.ChangeColor(_currentSocket._placedColor);
            transform.parent = _currentSocket.transform;
            transform.position = Vector3.zero;
        }

        private void Picked()
        {

        }

        public void OnPointerDown(PointerEventData eventData)
        {
            transform.parent = _canvas.transform;
            transform.position = eventData.position;

            _isOnSocket = false;
            _currentSocket?.ResetGraphics();
            _currentSocket = null;
        }
    }

}
