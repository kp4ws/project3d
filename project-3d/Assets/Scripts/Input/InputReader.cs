using Kp4wsGames.Events;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Kp4wsGames.Input
{    
	public class InputReader : MonoBehaviour, Controls.IPlayerActions
	{
        public Vector2 MovementValue { get; private set; }
        public GameEvent Event_Jump;
        public GameEvent Event_Interact;
        public GameEvent Event_Shoot;
        public GameEvent Event_Reload;
        public GameEvent Event_Zoom;
        //public GameEvent Event_Release;
        //public GameEvent Event_Press;
        public bool cursorLocked = true;

        private Controls controls;

        private void Start()
        {
            controls = new Controls();
            controls.Player.SetCallbacks(this);
            controls.Enable();
        }

        private void OnDestroy()
        {
            controls.Player.Disable();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MovementValue = context.ReadValue<Vector2>();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
        }

        public void OnJump(InputAction.CallbackContext context)
        {
         
        }

        public void OnRun(InputAction.CallbackContext context)
        {
        }

        public void OnZoom(InputAction.CallbackContext context)
        {
            if(context.started)
                Event_Zoom?.Raise();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;

            //Debug.Log("Interact with item");
            Event_Interact?.Raise();
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            if (context.started)
                Event_Shoot?.Raise();

            //if(context.started)
            //{
            //    ////Debug.Log("Mouse Pressed");
            //    Event_Press?.Raise();
            //}
            //else if(context.canceled)
            //{
            //    ////Debug.Log("Mouse Released");
            //    Event_Release?.Raise();
            //}
        }

        public void OnReload(InputAction.CallbackContext context)
        {
            if (!context.started)
                return;
            //Debug.Log("Reload");

            Event_Reload?.Raise();
        }
    }
}