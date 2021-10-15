using UnityEngine;

namespace wellside
{
    public class UI_Icon_Examinable : MonoBehaviour
    {
        Transform _ObjectTransform;
        ItemTrigger _itemEventTrigger;
        ExamineModeManager _examineState;
        Canvas _canvas;

        bool _isExamining;
        void Awake()
        {
            _ObjectTransform = GetComponentInParent<Transform>();

            _itemEventTrigger = _ObjectTransform.transform.root.GetChild(0).GetComponent<ItemTrigger>();
            _examineState = _ObjectTransform.transform.root.GetChild(0).GetComponent<ExamineModeManager>();
            _canvas = _ObjectTransform.GetChild(0).GetComponentInChildren<Canvas>();
        }

        private void OnEnable()
        {
            _itemEventTrigger.inRange += DisplayIcon;
            _itemEventTrigger.outOfRange += HideIcon;

            _examineState.OnExamineEnter += HideIcon;
            _examineState.OnExamineExit += DisplayIcon;
        }

        private void OnDisable()
        {
            _itemEventTrigger.inRange -= DisplayIcon;
            _itemEventTrigger.outOfRange -= HideIcon;

            _examineState.OnExamineEnter -= HideIcon;
            _examineState.OnExamineExit -= DisplayIcon;
        }

        void DisplayIcon()
        {
            _canvas.gameObject.SetActive(true);
        }

        void HideIcon()
        {
            _canvas.gameObject.SetActive(false);
        }
    }
}