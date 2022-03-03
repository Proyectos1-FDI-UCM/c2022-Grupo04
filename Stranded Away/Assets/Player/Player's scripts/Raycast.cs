using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    #region references
    private Transform _myTransform;
    private CharacterMovement _myRobotMovement;
    #endregion

    #region methods
    public bool IsGrounded()
    {
        if (Physics2D.Raycast(_myTransform.position, Vector2.down, 0.1f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _myRobotMovement = GetComponent<CharacterMovement>();
    }
}

