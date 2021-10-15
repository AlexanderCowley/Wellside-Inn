using UnityEngine;

namespace wellside
{
    public class GroundedCheck : MonoBehaviour
    {
        Transform _ObjectTransform;

        [SerializeField] float _groundDistance;

        [SerializeField] LayerMask _groundMask;
        void Awake() => _ObjectTransform = GetComponent<Transform>();

        public bool isGrounded() => Physics.CheckSphere
            (_ObjectTransform.position, _groundDistance, _groundMask);
    }
}