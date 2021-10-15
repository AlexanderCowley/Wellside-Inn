using System;
using UnityEngine.UI;
using UnityEngine;

namespace wellside
{
    public class ExamineAction : MonoBehaviour
    {
        /// <summary>
        /// ScriptableObject Data
        /// </summary>
        string _actionTitle;

        Vector2 btn_Pos;
        Vector2 btn_direction;

        Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            //_button.onClick.AddListener();
        }

        private void OnDisable()
        {
            //_button.onClick.RemoveListener();
        }

        void InitData()
        {

        }
    }
}