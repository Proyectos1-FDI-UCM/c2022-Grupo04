using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    #region references
    private Transform _myTransform;
    private Rigidbody2D _myRigidBody;
    private LayerMask _myLayer;
    private InputManager _myInput;
    private GroundCheck _myGroundCheck;
    private LayerMask _plataform;
    #endregion

    #region properties
    [SerializeField]
    private float maxDistance = 100f;
    [SerializeField]
    private float speed = 1f;
    private Vector2 target;
    [HideInInspector] public bool moving = false;
    #endregion
    #region methods
    public bool Obstaculos(Vector2 _hookdirection)
    {
        Debug.DrawRay(_myTransform.position, _hookdirection);
        RaycastHit2D hit = Physics2D.Raycast(_myTransform.position, _hookdirection.normalized, _hookdirection.magnitude, _plataform);
        Debug.Log(hit.collider);
        return hit.collider != null;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _myLayer = LayerMask.GetMask("Grabbing");
        _myRigidBody = GetComponent<Rigidbody2D>();
        _myInput = GetComponent<InputManager>();
        _myGroundCheck = GetComponentInChildren<GroundCheck>();
        _plataform = LayerMask.GetMask("Plataform");
       
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            _myInput.enabled = false;
            _myRigidBody.gravityScale = 0;
            _myRigidBody.velocity = new Vector2(0f, 0f);
            float step = speed * Time.deltaTime;
            Vector2 direction = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
            direction.Normalize();
            transform.Translate(direction * step);
            
            if (Vector2.Distance(transform.position, target) < 1.5f)
            {
                _myRigidBody.gravityScale = 1;
                moving = false;
                _myInput.enabled = true;
            }
            
            
            
        }
    }

    public void StartGrapple()
    {
        if (_myGroundCheck.IsGrounded())
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float distance = direction.magnitude;

            //Raycast (origin, direction, maxDistance, LayerMask, queryTriggerInteraction); devuelve un booleano
            if (!Obstaculos(direction))
            {
                RaycastHit2D hit = Physics2D.Raycast(_myTransform.position, direction.normalized, Mathf.Min(distance, maxDistance), _myLayer);
                Debug.Log("RayCast lanzado");
                Debug.DrawRay(_myTransform.position, direction.normalized, Color.blue, 20);
                if (hit.collider != null)
                {
                    Debug.Log("Tocado");
                    target = hit.transform.position;
                    moving = true;
                }
            }
                
        }
    }
}
