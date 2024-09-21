using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerInput: MonoBehaviour
{
        public PlayerMovement playerMovement;
        public float borders;
        public Camera camera;
        private float currentPosition;
        private float previousPosition;
        private bool isClick;
    public void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                isClick = false;
            }
            var mousePosition = Input.mousePosition;
            var mouseX = camera.ScreenToViewportPoint(mousePosition).x;
            mouseX = (mouseX - 0.5f) * borders;
            if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false)
            {
                currentPosition = previousPosition = mouseX;
                isClick = true;
            }
            else if (isClick)
            {
                currentPosition = mouseX;
                var shift = currentPosition - previousPosition;
                playerMovement.MoveDiag(shift);
                previousPosition = currentPosition;
            }
        }
}