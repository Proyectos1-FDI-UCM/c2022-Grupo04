using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject _ray1;
    [SerializeField]
    private GameObject _ray2;
    [SerializeField]
    private GameObject _ray3;
    private Raycast _myRaycast1, _myRaycast2, _myRaycast3;
    #endregion

    #region methods
    public bool IsGrounded()
    {
        if (_myRaycast1.IsGrounded() || _myRaycast2.IsGrounded() || _myRaycast3.IsGrounded())
        {
            return true;
        }
        else return false;
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _myRaycast1 = _ray1.GetComponent<Raycast>();
        _myRaycast2 = _ray2.GetComponent<Raycast>();
        _myRaycast3 = _ray3.GetComponent<Raycast>();
    }
}
