using System.Collections;
using UnityEngine;

namespace wellside
{
    public class ExamineModeManager : MonoBehaviour
    {
        public delegate void OnExamine();
        public event OnExamine OnExamineEnter;
        public event OnExamine OnExamineExit;

        public delegate void PlayerStateHandler(Movement player);
        public event PlayerStateHandler PlayerStateEnabled;
        public event PlayerStateHandler PlayerStateDisabled;

        Input_Interaction _input;

        bool _isExamining;

        Movement _playerMovement;

        WaitForSeconds _waitForSeconds;
        void Awake()
        {
            _input = GetComponent<Input_Interaction>();
        }

        private void OnEnable() => _input.onInteract += TogglePlayerState;

        private void OnDisable() => _input.onInteract -= TogglePlayerState;

        private void OnTriggerEnter(Collider other)
        {
            _playerMovement = other.GetComponent<Movement>();
        }

        //Refactor
        void TogglePlayerState()
        {
            _isExamining = !_isExamining;

            if (_isExamining)
            {
                OnExamineEnter?.Invoke();
                PlayerStateDisabled?.Invoke(_playerMovement);
            } 
            else if (!_isExamining)
            {
                OnExamineExit?.Invoke();
                PlayerStateEnabled?.Invoke(_playerMovement);
            }  
            else
                return;
        }
    }
}