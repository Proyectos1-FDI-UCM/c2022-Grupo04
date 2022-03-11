using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    #region parameters 
    [SerializeField]
    private float _movementSpeed = 1.0f;
    [SerializeField]
    private float _jumpForce = 5.0f;
    [HideInInspector]
    public Vector2 m_JumpVector;
    #endregion

    #region properties
    [HideInInspector]
    public Vector2 m_movementDirection = Vector2.zero;
    #endregion

    #region references
    private Transform _myTransform;
    private GroundCheck _myGroundCheck;
    private Rigidbody2D _myRigidBody;
    #endregion

    #region methods
    public void SetDirection(Vector2 newDirection)
    {
        m_movementDirection = newDirection;
    }

    public void JumpRequest()
    {
        if (_myGroundCheck.IsGrounded())
        {
            m_JumpVector = new Vector2(_myRigidBody.velocity.x, _jumpForce);
            _myRigidBody.velocity = m_JumpVector;
        }
    }
    #endregion 

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _myRigidBody = GetComponent<Rigidbody2D>();
        _myGroundCheck = GetComponentInChildren<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        _myTransform.Translate(_movementSpeed * Time.deltaTime * m_movementDirection); //usar rigidbody para mover a los personajes(+eficiente, no vibra al chocar)
        if (m_movementDirection.x > 0) _myTransform.localScale = new Vector2(1f, 1f);
        else if (m_movementDirection.x < 0f) _myTransform.localScale = new Vector2(-1f, 1f);
    }
}
