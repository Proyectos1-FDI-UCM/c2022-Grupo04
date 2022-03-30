using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltStateManager : MonoBehaviour
{
    #region properties
    private enum BeltParameters {Speed, Direction, Both}
    [SerializeField]
    private BeltParameters _parameter;
    private float _initialSpeed;
    private int _initialDirection;
    #endregion

    #region references
    private BeltMovement _myMovement;
    private Transform _myTransform;
    #endregion

    #region parameters
    [SerializeField]
    private float _multiple = 2f;
    #endregion

    #region methods
    public void Active()
    {
        if(_parameter == BeltParameters.Speed)
        {
            _myMovement.m_speed *= _multiple;
        }
        else if(_parameter == BeltParameters.Direction)
        {
            _myMovement.m_direction *= -1;
            _myTransform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
        else
        {
            _myMovement.m_speed *= _multiple;
            _myTransform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
    }

    public void Disabled()
    {
        if (_parameter == BeltParameters.Speed)
        {
            _myMovement.m_speed = _initialSpeed;
        }
        else if (_parameter == BeltParameters.Direction)
        {
            _myMovement.m_direction = _initialDirection;
        }
        else
        {
            _myMovement.m_speed = _initialSpeed;
            _myMovement.m_direction = _initialDirection;
            
        }
    }
    #endregion

    private void Start()
    {
        _myMovement = GetComponent<BeltMovement>();
        _initialSpeed = _myMovement.m_speed;
        _initialDirection = _myMovement.m_direction;
        _myTransform = transform;
    }
}
