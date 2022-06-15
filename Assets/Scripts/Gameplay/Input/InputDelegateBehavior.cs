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
    private float _laneChange, _numberOfHits;
    private bool _isMoving, _isShooting, _shoot;
    public bool IsShooting { get => _isShooting; set => _isShooting = value; }
    public bool Shoot { get => _shoot; set => _shoot = value; }
    public bool IsMoving { get => _isMoving; }
    private void Awake()
    {
        Instance = this;
        _playerControls = new PlayerControls();
        _playerMovement = GetComponent<PlayerMovementBehavior>();

    }
    private void OnEnable() { _playerControls.Enable();}

    private void OnDisable() { _playerControls.Disable();}

    // Start is called before the first frame update
    void Start() {  _playerControls.Player.Shoot.performed += context => _gun.Fire();}
    private void FixedUpdate()
    {
        //press esc key on key board and b on controller to exit game
        //if (_playerControls.Player.Exit.activeControl.IsPressed())
        //    Application.Quit();

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

        //if (_playerControls.Ninja.Shoot.activeControl.IsPressed())
        //    _shoot = true;
    }
    /// <summary>
    /// Checks to see if th eplayer is moving or shooting
    /// </summary>
    public void Update()
    {
        _isMoving = _playerControls.Player.Movement.activeControl.IsPressed();
    }
}
