using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rB;
    [SerializeField] private float jumpH = 200f;
    [SerializeField] private float mvtSpeed = 5f;
    private Vector3 mvt;

    private Controls _controls = null;
    // Start is called before the first frame update
    void Awake()
    {
        _controls = new Controls();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Jump()
    {
            
    }

    public void Move()
    {
        var movementInput = _controls.Mvt
    }

    private void OnEnable() => _controls.Mvt.Enable();

    private void OnDisable() => _controls.Mvt.Disable();
}
