using System.Collections;
using UnityEngine;

namespace wellside
{
    public class UI_Canvas_Toggle : MonoBehaviour
    {
        Transform _ObjectTransform;
        ExamineModeManager _examineState;
        Canvas _canvas;
        bool _isActive = false;
        void Awake()
        {
            _ObjectTransform = GetComponentInParent<Transform>();

            _examineState = _ObjectTransform.transform.root.GetChild(0).GetComponent<ExamineModeManager>();
            _canvas = _ObjectTransform.GetChild(0).GetComponentInChildren<Canvas>();
        }

        private void OnEnable()
        {
            _examineState.OnExamineEnter += DisplayCanvas;
            _examineState.OnExamineExit += HideCanvas;
        }

        private void OnDisable()
        {
            _examineState.OnExamineEnter -= DisplayCanvas;
            _examineState.OnExamineExit -= HideCanvas;
        }

        void DisplayCanvas()
        {
            _canvas.gameObject.SetActive(true);
        }

        void HideCanvas()
        {
            StartCoroutine(stateChangeDelay());
            
        }

        IEnumerator stateChangeDelay()
        {
            _isActive = true;
            while (_isActive)
            {
                yield return new WaitForSeconds(2f);
                _isActive = false;
                _canvas.gameObject.SetActive(false);
            }
            
        }
    }
}