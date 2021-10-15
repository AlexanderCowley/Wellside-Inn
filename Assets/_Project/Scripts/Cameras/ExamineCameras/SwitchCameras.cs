using UnityEngine;

namespace wellside
{
    public class SwitchCameras : MonoBehaviour
    {
        Transform _ObjectTransform;

        Camera _playerCamera;
        Camera _itemCamera;
        ExamineModeManager _examineState;
        void Awake()
        {
            _ObjectTransform = GetComponent<Transform>();

            _examineState = _ObjectTransform.GetComponent<ExamineModeManager>();

            _itemCamera = _ObjectTransform.GetComponentInChildren<Camera>();
        }

        private void OnEnable() 
        { 
            _examineState.PlayerStateDisabled += ChangeCameras;
            //_examineState.PlayerStateEnabled += SwitchToPlayerCam;
        }

        private void OnDisable()
        {
            _examineState.PlayerStateDisabled -= ChangeCameras;
            //_examineState.PlayerStateEnabled -= SwitchToPlayerCam;
        }

        void ChangeCameras(Movement player)
        {
            _playerCamera = player.transform.root.GetChild(2).
                GetComponent<Camera>();

            _itemCamera.enabled = true;
            _playerCamera.enabled = false;
        }

        void SwitchToPlayerCam(Movement player)
        {
            _playerCamera = player.transform.root.GetChild(2).
                GetComponent<Camera>();

            _itemCamera.enabled = false;
            _playerCamera.enabled = true;
        }
    }
}