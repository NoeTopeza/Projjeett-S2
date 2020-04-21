using System;
using UnityEngine;

namespace Script
{
    public class Cursor : MonoBehaviour
    {
        public GameObject cursor;
        public GameObject controller;
        private Controls _controls; //= null
        private Vector2 _move;
        
        private void Awake()
        {
            _controls = new Controls();
            cursor.transform.position = controller.transform.position;

            _controls.CurseurVR.Select.performed += ctx => Transform();
            _controls.CurseurVR.MoveC.performed += ctx => _move = ctx.ReadValue<Vector2>();
            _controls.CurseurVR.MoveC.canceled += ctx => _move = Vector2.zero;
        }

        private void Update()
        {
            Vector2 m = new Vector2(0, _move.y) * Time.deltaTime;
            transform.Translate(m, Space.Self);
        }

        private void Transform()
        {
            
        }

        private void OnEnable() => _controls.CurseurVR.Enable();

        private void OnDisable() => _controls.CurseurVR.Disable();
    }
}
