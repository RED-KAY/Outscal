namespace Singleton.Assignment1
{
    using UnityEngine;
    using UnityEngine.UI;

    public class Placeable : MonoBehaviour
    {
        [SerializeField] Image _image;

        Color _originalColor;

        public int _type; // 1 = Socket, 2 = Collection

        public Color _highlightColor;
        public Color _placedColor;

        private void Start()
        {
            _originalColor = _image.color;
        }

        public void ChangeColor(Color color)
        {
            _image.color = color;
        }

        public void ResetGraphics()
        {
            _image.color = _originalColor;
        }
    }
}

