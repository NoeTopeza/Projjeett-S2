using UnityEngine;

namespace Script
{
    public class PlayerMovement : MonoBehaviour
    {
        public Rigidbody rB;
        [SerializeField] private float jumpH = 200f;
        [SerializeField] private float mvtSpeed = 5f;
        //[SerializeField] private float gravity = 9.81f;

        private Controls _controls; //= null
        private Vector2 _move;

        public Transform grCheck;
        public float grDistance = 0.4f;
        public LayerMask grMask;
        private bool _isGrounded;
        //private Vector3 _velocity; //lié à la gravité
        private void Awake()
        {
            _controls = new Controls();

            _controls.Player.Jump.performed += ctx => Jump();

            _controls.Player.Move.performed += ctx => _move = ctx.ReadValue<Vector2>();
            _controls.Player.Move.canceled += ctx => _move = Vector2.zero;

        }
    
        private void Update()
        {
            _isGrounded = Physics.CheckSphere(grCheck.position,grDistance,grMask);
        
            //Move
            Vector2 m = new Vector2(_move.x, _move.y) * Time.deltaTime;
            transform.Translate(m, Space.Self);
        
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
            var jumpInput = _controls.Player.Jump.triggered;
            if (jumpInput)
            {
                rB.AddForce(0,jumpH,0);
            }
        }

        private void OnEnable() => _controls.Player.Enable();

        private void OnDisable() => _controls.Player.Disable();
    }
}
