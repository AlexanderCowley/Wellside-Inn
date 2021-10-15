using System;
using UnityEngine;

namespace wellside
{
    public class Input_Interaction : MonoBehaviour
    {
        Transform _ObjectTransform;

        ItemTrigger _itemTrigger;
        LockMovement _lockPlayer;

        Movement _playerMovement;

        public delegate void OnInteract();
        public OnInteract onInteract;

        bool _canInteract;
        void Awake()
        {
            _ObjectTransform = GetComponent<Transform>();

            _itemTrigger = _ObjectTransform.GetComponent<ItemTrigger>();
            _lockPlayer = _ObjectTransform.GetComponent<LockMovement>();
        }

        private void OnEnable()
        {
            _itemTrigger.inRange += ActivateInput;
            _itemTrigger.outOfRange += DeactivateInput;
        }

        private void OnDisable()
        {
            _itemTrigger.inRange -= ActivateInput;
            _itemTrigger.outOfRange -= DeactivateInput;
        }

        private void ActivateInput() => _canInteract = true;

        void DeactivateInput() => _canInteract = false;

        private void OnTriggerEnter(Collider other)
        {
            _playerMovement = other.GetComponent<Movement>();
        }

        private void Update()
        {
            
            if (_canInteract) 
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    onInteract?.Invoke();
                }
                    
            }

        }
    }
}