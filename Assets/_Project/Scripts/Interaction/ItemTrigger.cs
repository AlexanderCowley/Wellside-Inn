using UnityEngine;

namespace wellside
{
    public class ItemTrigger : MonoBehaviour
    {
        Movement _player;

        public Movement PlayerMovement
        {
            get { return _player; }
        }

        Camera _camera;

        public Camera PlayerCamera
        {
            get { return _camera; }
        }

        public delegate void InRange();
        public event InRange inRange;

        public delegate void OutOfRange();
        public event OutOfRange outOfRange;

        private void OnTriggerEnter(Collider other)
        {
            _player = other.GetComponent<Movement>();
            _camera = other.transform.root.GetChild(2).GetComponent<Camera>();
            
            if (_player != null)
                inRange?.Invoke();
            //Get Inventory??
        }

        private void OnTriggerExit(Collider other)
        {
            _player = other.GetComponent<Movement>();
            if (_player != null)
                outOfRange?.Invoke();
        }
    }
}