using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;

namespace wellside
{
    public class MoveButton : MonoBehaviour
    {
        RectTransform _objectTransform;

        Vector3 _originalLocation;
        [SerializeField] Transform _targetDestination;
        [SerializeField] float _speed;

        [SerializeField] Ease _easeType = Ease.Linear;

        Tween _objectTween;

        ExamineModeManager _examineState;

        Button _btn;

        void Awake()
        {
            _objectTransform = GetComponent<RectTransform>();
            _btn = GetComponent<Button>();

            _examineState = _objectTransform.root.GetChild(0).GetComponent<ExamineModeManager>();

            _originalLocation = _objectTransform.position;

            ToggleBtnInteractivity(false);
        }

        void InitMoveTween()
        {
            DOTween.Init(false);

            _objectTween = _objectTransform.DOMove(_targetDestination.position, _speed).
                            SetEase(_easeType).
                            SetAutoKill(false).
                            SetLoops(2, LoopType.Yoyo).
                            Pause().
                            SetRecyclable(false);

            _objectTween.Restart();
            _objectTween.Pause();
        }

        void ToggleBtnInteractivity(bool isComplete) => _btn.interactable = isComplete;

        private void OnEnable()
        {
            _examineState.OnExamineExit += MoveObjectBack;
            MoveObject();
        }

        private void OnDisable() => _examineState.OnExamineExit -= MoveObjectBack;

        void MoveObject()
        {
            InitMoveTween();
            _objectTween.Play();
            StartCoroutine(waitForCompletion());
        }

        IEnumerator waitForCompletion()
        {
            yield return _objectTween.WaitForElapsedLoops(1);

            _objectTween.Pause();
            ToggleBtnInteractivity(true);
        }

        void MoveObjectBack()
        {
            _objectTransform.DOMove(_originalLocation, _speed).
                            SetEase(_easeType).
                            SetAutoKill(false).
                            SetRecyclable(false);

            ToggleBtnInteractivity(false);
        }

    }
}