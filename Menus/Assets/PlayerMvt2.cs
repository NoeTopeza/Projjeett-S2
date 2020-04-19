using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMvt2 : MonoBehaviour
{
    public Rigidbody rB;
    [SerializeField] private float jumpH = 200f;
    [SerializeField] private float mvtSpeed = 5f;
    //[SerializeField] private float gravity = 9.81f;

    private Controls _controls = null;

    public Transform grCheck;
    public float grDistance = 0.4f;
    public LayerMask grMask;
    private bool _isGrounded;
    //private Vector3 _velocity;
    void Awake()
    {
        _controls = new Controls();
    }
    
    void Update()
    {
        _isGrounded = Physics.CheckSphere(grCheck.position,grDistance,grMask);
        
        Move();
        
        if (_isGrounded /*&& _velocity.y < 0 */)    //Touche le sol ?
        {
            Jump();           //si oui : il peut sauter et son Epp est reset
            //_velocity.y = -1f;
        }

        
        /*
        else
        {                 //sinon : il gagne en vitesse vers le bas
            _velocity.y -= gravity * Time.deltaTime * Time.deltaTime;
        }

        rB.AddForce(_velocity); //on applique la gravité
        */
    }
    
    

    private void Jump()
    {
        var jumpInput = _controls.Player_2.Jump.triggered;
        if (jumpInput)
        {
            rB.AddForce(0,jumpH,0);
        }
    }

    private void Move()
    {
        var movementInput = _controls.Player_2.Move.ReadValue<Vector2>();

        var movement = new Vector3
        {
            x = movementInput.x,
            z = movementInput.y
        }.normalized;
        
        transform.Translate(movement * (mvtSpeed * Time.deltaTime));
    }

    private void OnEnable() => _controls.Player_2.Enable();

    private void OnDisable() => _controls.Player_2.Disable();
}