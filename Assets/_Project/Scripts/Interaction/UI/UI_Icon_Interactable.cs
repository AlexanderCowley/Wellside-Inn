using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace wellside
{
    public class UI_Icon_Interactable : MonoBehaviour
    {
        Transform _ObjectTransform;
        ItemTrigger _itemEventTrigger;
        Canvas _canvas;
        void Awake()
        {
            _ObjectTransform = GetComponentInParent<Transform>();

            _itemEventTrigger = _ObjectTransform.transform.root.GetChild(0).GetComponent<ItemTrigger>();
            _canvas = _ObjectTransform.GetChild(0).GetComponentInChildren<Canvas>();
        }

        private void OnEnable()
        {
            _itemEventTrigger.inRange += DisplayIcon;
            _itemEventTrigger.outOfRange += HideIcon;
        }

        private void OnDisable()
        {
            _itemEventTrigger.inRange -= DisplayIcon;
            _itemEventTrigger.outOfRange -= HideIcon;
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