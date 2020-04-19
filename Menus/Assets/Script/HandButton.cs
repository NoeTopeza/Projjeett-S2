using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

namespace Script
{
     public class HandButton : XRBaseInteractable
    {
        //public UnityEvent OnPress = null;
        
        public delegate void _OnPress();
        public static event _OnPress OnPress;

        private XRBaseInteractor _hoverInteractor = null;
        private float _previousHandHeight = 0.0f;
        private float _yMin = 0.0f;
        private float _yMax = 0.0f;
        private bool _previousPress = false;
        protected override void Awake()
        {
            base.Awake();
            onHoverEnter.AddListener(StartPress);
            onHoverExit.AddListener(EndPress);
        }

        private void OnDestroy()
        {
            onHoverEnter.RemoveListener(StartPress);
            onHoverExit.RemoveListener(EndPress);
        }

        private void StartPress(XRBaseInteractor interactor)
        {
            _hoverInteractor = interactor;
            _previousHandHeight = GetLocalYPosition(_hoverInteractor.transform.position);
        }
        
        private void EndPress(XRBaseInteractor interactor)
        {
            _hoverInteractor = null;
            _previousHandHeight = 0.0f;

            _previousPress = false;
            SetYPosition(_yMax);
        }

        private void Start()
        {
            SetMinMax();
        }

        private void SetMinMax()
        {
            Collider collider = GetComponent<Collider>();
            var localPosition = transform.localPosition;
            _yMin = localPosition.y - (collider.bounds.size.y * 0.5f);
            _yMax = localPosition.y;
        }

        public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
        {
            if (_hoverInteractor)
            {
                float newHandHeight = GetLocalYPosition(_hoverInteractor.transform.position);
                float handDifference = _previousHandHeight - newHandHeight;
                _previousHandHeight = newHandHeight;

                float newPosition = transform.localPosition.y - handDifference;
                SetYPosition(newPosition);
                
                CheckPress();
            }
        }

        private float GetLocalYPosition(Vector3 position)
        {
            Vector3 localPosition = transform.root.InverseTransformPoint(position);
            return localPosition.y;
        }

        private void SetYPosition(float position)
        {
            Vector3 newPosition = transform.localPosition;
            newPosition.y = Mathf.Clamp(position, _yMin, _yMax);
            transform.localPosition = newPosition;
        }

        private void CheckPress()
        {
            bool inPosition = InPosition();

            if (inPosition && inPosition != _previousPress)
                OnPress?.Invoke();
        }

        private bool InPosition()
        {
            float inRange = Mathf.Clamp(transform.localPosition.y, _yMin, _yMin + 0.01f);
            return transform.localPosition.y == inRange;
        }
    }
}
