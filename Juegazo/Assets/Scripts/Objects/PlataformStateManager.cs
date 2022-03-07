using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformStateManager : MonoBehaviour
{
    #region references
    private Transform _myTransform;
    #endregion

    #region parameters
    [SerializeField]
    private Vector2 _initialPos;
    [SerializeField]
    private Vector2 _finalPos;
    #endregion

    #region methods
    public void InitialState()
    {
        _myTransform.position = _initialPos;
    }

    public void FinalState()
    {
        _myTransform.position = _finalPos;
    }




    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _myTransform.position = _initialPos;
    }
    #endregion
}
