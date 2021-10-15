using UnityEngine;

namespace wellside
{
    public class LockMovement : MonoBehaviour
    {
        ExamineModeManager _examineState;

        private void Awake()
        {
            _examineState = GetComponent<ExamineModeManager>();
        }

        private void OnEnable()
        {
            _examineState.PlayerStateDisabled += LockPlayerMovement;
            _examineState.PlayerStateEnabled += UnlockMovement;
        }

        private void OnDisable()
        {
            _examineState.PlayerStateDisabled -= LockPlayerMovement;
            _examineState.PlayerStateEnabled -= UnlockMovement;
        }

        void LockPlayerMovement(Movement player)
        {
            player.enabled = false;
        }

        void UnlockMovement(Movement player)
        {
            player.enabled = true;
        }

    }
}