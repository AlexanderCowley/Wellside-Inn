using UnityEngine;

namespace wellside
{
    public class CursorManager : MonoBehaviour
    {
        ExamineModeManager _examineState;

        Texture2D _cursorSprite;

        //Look at if you want to go for other platforms
        CursorMode cursorMode = CursorMode.Auto;
        
        void Awake()
        {
            _examineState = GetComponent<ExamineModeManager>();
            LockCursor();
        }



        private void OnEnable() 
        { 
            _examineState.OnExamineEnter += UnlockCursor; 
            _examineState.OnExamineExit += LockCursor; 
        }

        private void OnDisable()
        {
            _examineState.OnExamineEnter -= UnlockCursor;
            _examineState.OnExamineExit -= LockCursor;
        }

        void LockCursor() 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void UnlockCursor() 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        /// <summary>
        /// This is going to be used for FPS Mode!!!
        /// </summary>
        void SetNewCursor()
        {
            Vector2 HotSpot = Vector2.zero;
            Cursor.SetCursor(_cursorSprite, HotSpot, cursorMode);
        }
    }
}