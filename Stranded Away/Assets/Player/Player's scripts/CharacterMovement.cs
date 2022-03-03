using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    #region parameters 
    [SerializeField]
    private float _movementSpeed;
    [SerializeField]
    private float _jumpForce = 4500.0f;
    [SerializeField]
    private GameObject _raycast;
    #endregion

    #region properties
    private Vector2 _movementDirection = Vector2.zero;
    private Transform _myTransform;
    private Raycast _myRaycast;
    #endregion


    #region methods
    public void SetDirection(Vector2 newDirection, float speed)
    {
        _movementDirection = newDirection;
        _movementSpeed = speed;
    }

    public void JumpRequest()
    {
        if (_myRaycast.IsGrounded())
        {
            GetComponent<Rigidbody2D>().AddForce(_jumpForce * Time.deltaTime * Vector2.up);
        }
    }
    #endregion 

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _myRaycast = _raycast.GetComponent<Raycast>();
    }

    // Update is called once per frame
    void Update()
    {
        _myTransform.Translate(_movementSpeed * Time.deltaTime * _movementDirection);
        if (_movementDirection.x> 0f) _myTransform.localScale = new Vector2(1f, 1f);
        else if (_movementDirection.x < 0f) _myTransform.localScale = new Vector2(-1f, 1f);
    }
}
