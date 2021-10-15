using UnityEngine;

namespace wellside
{
    public class AnimationEventTrigger : MonoBehaviour
    {
        Transform _ObjectTransform;
        Animator _animator;
        Input_Interaction _inputEvent;

        bool _isAnimTriggered;
        void Awake()
        {
            _ObjectTransform = GetComponent<Transform>();

            _animator = GetComponent<Animator>();
            _inputEvent = _ObjectTransform.transform.root.GetChild(0).
                GetComponentInChildren<Input_Interaction>();
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        void SubscribeEvents()
        {
            _inputEvent.onInteract += TriggerAnimation;
        }

        void UnSubscribeEvents()
        {
            _inputEvent.onInteract -= TriggerAnimation;
        }

        void TriggerAnimation()
        {
            _isAnimTriggered = !_isAnimTriggered;
            _animator.SetBool("_anim_isDoorOpen", _isAnimTriggered);
        }
    }
}