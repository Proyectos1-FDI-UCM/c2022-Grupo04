using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrounded : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject _grounded;
    private GroundCheck _myGroundCheck;
    private Transform _myTransform;
    private Transform _groundTransform;
    private CharacterMovement _myCharacterMovement;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _myGroundCheck = GetComponentInChildren<GroundCheck>();
        _groundTransform = _grounded.transform;
        _myCharacterMovement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!_myGroundCheck.IsGrounded())
        {
            Debug.Log("No" + gameObject);
            _myTransform.Rotate(0, 180, 0);
        }*/

        if (!Physics2D.Raycast(_groundTransform.position, Vector2.down, 0.1f))
        {
            _myTransform.Rotate(0, 180, 0);
            _myCharacterMovement.SetDirection(_myTransform.forward);
        }
    }
}
