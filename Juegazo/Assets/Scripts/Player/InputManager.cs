using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region references
    private CharacterMovement _movementComponent;
    private Hook _myHook;
    private RobotBox _robotBox;
    private GroundCheck _myGroundcheck;
    [SerializeField]
    private GameObject UIManager;
    private UIManager _myUIManager;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _movementComponent = GetComponent<CharacterMovement>();
        _myHook = GetComponent<Hook>();
        _robotBox = GetComponent<RobotBox>();
        _myGroundcheck = GetComponentInChildren<GroundCheck>();
        _myUIManager = UIManager.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 _direction = Vector2.zero;  //si no pulsas nada, no se mueve
        if (Input.GetKey(KeyCode.A))
            _direction.x = -1.0f;

        if (Input.GetKey(KeyCode.D))
            _direction.x = 1.0f;

        if (Input.GetKeyDown(KeyCode.W))
        {
            _movementComponent.JumpRequest();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_myGroundcheck.IsGrounded())
            {
                _robotBox.Box();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (_myGroundcheck.IsGrounded())
            {
                _myHook.StartGrapple();
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            _myUIManager.Pause();
        }

        _direction.Normalize();
        _movementComponent.SetDirection(_direction);
    }
}