using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDelegateBehavior : MonoBehaviour
{
    public static InputDelegateBehavior Instance;
    private PlayerControls _playerControls;
    private PlayerMovementBehavior _playerMovement;
    [SerializeField]
    private FireBehaviour _gun;
    private float _laneChange;
    private float _numberOfHits;

    private bool _isMoving;
    private bool _isShooting;
    public bool IsShooting { get => _isShooting; set => _isShooting = value; }

    public bool IsMoving { get => _isMoving; }

    private void Awake()
    {
        Instance = this;
        _playerControls = new PlayerControls();
        _playerMovement = GetComponent<PlayerMovementBehavior>();

    }
    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerControls.Player.Shoot.performed += context => _gun.Fire();
    }

    /// <summary>
    /// Checks to see if th eplayer is moving or shooting
    /// </summary>
    public void Update()
    {
        Vector2 moveDirection = _playerControls.Player.Movement.ReadValue<Vector2>();
        _laneChange = moveDirection.x;
        _numberOfHits++;
        if (_numberOfHits == 4)
        {
            _playerMovement.Move((int)(_laneChange));

            _numberOfHits = 0;
        }

        //After the player moves sets the animation to false
        if (IsMoving)
            _isMoving = false;

        _isShooting = _playerControls.Player.Shoot.activeControl.IsPressed();
    }

}
