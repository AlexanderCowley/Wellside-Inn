using UnityEngine;

namespace wellside
{
    public class CharacterGravity : MonoBehaviour
    {
        Vector3 _velocity;
        float _gravity = -19.62f;
        CharacterController _characterController;

        [SerializeField] GroundedCheck _groundCheck;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        void ApplyGravity()
        {
            if (_groundCheck.isGrounded() && _velocity.y < 0)
                ResetVelocity();
            else
            {
                _velocity.y += _gravity * Time.deltaTime;
                _characterController.Move(_velocity * Time.deltaTime);
            }
                
        }

        void ResetVelocity() => _velocity.y = -2f; 

        void Update()
        {
            ApplyGravity();
        }
    }
}