using System;
using UnityEngine;

namespace Resources.Player.Scripts
{
    public class PlayerMovements : MonoBehaviour
    {
        // Fields

        private PlayerInput _playerInput;

        private PlayerInput.MovementsActions _movements;

        private CharacterController _characterController;
        
        [SerializeField]
        private float _speed = 3.0f;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _movements = _playerInput.Movements;
        }

        private void OnEnable()
        {
            _movements.Enable();
        }

        private void OnDisable()
        {
            _movements.Disable();
        }

        // Start is called before the first frame update
        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            PlayerMove();
        }

        private void PlayerMove()
        {
            var moveInput = _movements.Move.ReadValue<Vector2>();
            var moveVector = _speed * Time.fixedDeltaTime * new Vector3(moveInput.x, 0.0f, moveInput.y);
            
            _characterController.Move(moveVector);
        }
    }
}
