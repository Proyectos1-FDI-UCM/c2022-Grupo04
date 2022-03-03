using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region references
    private CharacterMovement _movementComponent;
    private Hook _myHook;
    private RobotBox _robotBox;
    private Raycast _myRaycast;
    private float _characterSpeed = 5f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _movementComponent = GetComponent<CharacterMovement>();
        _myHook = GetComponent<Hook>();
        _robotBox = GetComponent<RobotBox>();
        _myRaycast = GetComponentInChildren<Raycast>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 _direction = Vector2.zero;  //si no pulsas nada, no se mueve
        if (Input.GetKey(KeyCode.A))
            _direction.x = -1.0f;

        if (Input.GetKey(KeyCode.D))
            _direction.x = 1.0f;

        if (Input.GetKey(KeyCode.W))
        {
            _movementComponent.JumpRequest();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_myRaycast.IsGrounded())
            {
                 _robotBox.Box();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            _myHook.StartGrapple();
        }

        _direction.Normalize();
        _movementComponent.SetDirection(_direction, _characterSpeed);
    }
}