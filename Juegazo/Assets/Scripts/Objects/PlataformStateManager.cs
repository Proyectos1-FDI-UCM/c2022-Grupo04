using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformStateManager : MonoBehaviour
{
    #region references
    private Transform _myTransform;
    #endregion

    #region parameters
    private Vector2 _startposition;
    [SerializeField]
    private Vector2 _initialdirection;
    [SerializeField]
    private Vector2 _distance;
    [SerializeField]
    private float _speed;
    private Vector2 _direction;
    private Vector2 _finalposition;
    private bool _isrunning;
    private bool _isreturning;
    #endregion




    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _startposition= _myTransform.position;
        _direction = _initialdirection;
        _finalposition = _startposition + (_distance * _direction);
        _isreturning = false; _isreturning = false;
    }
    #region methods
    public void Move() // pensado para mover en un eje a la vez 
    {
        _isrunning = true;
        _isreturning = false;
    }
    public void Return()
    {
        _isrunning = false;
        _isreturning = true;
    }
    #endregion
    void Update()
    {
        if(_isrunning)
        {
            if (_initialdirection.x == 1 || _initialdirection.y == 1) //la plataforma se mueve hacia arriba o hacia la derecha
            {
                if (_myTransform.position.y <= _finalposition.y && _myTransform.position.x <= _finalposition.x)
                {
                    _myTransform.position = Vector2.MoveTowards(_myTransform.position, ((Vector2)_myTransform.position + _direction), _speed * Time.deltaTime);
                    
                }
            }
            else
            {
                if (_myTransform.position.y >= _finalposition.y && _myTransform.position.x >= _finalposition.x)
                {
                    _myTransform.position = Vector2.MoveTowards(_myTransform.position, ((Vector2)_myTransform.position + _direction), _speed * Time.deltaTime);
                }

            }
        }
        if(_isreturning)
        {

            if (_initialdirection.x == 1 || _initialdirection.y == 1) //la plataforma se mueve hacia arriba o hacia la derecha
            {
                _myTransform.position = Vector2.MoveTowards(_myTransform.position,_startposition , _speed * Time.deltaTime);
                if (_myTransform.position.y <= _startposition.y && _myTransform.position.x <= _startposition.x)
                {
                    _isreturning = false;
                }
            }
            else
            {
                _myTransform.position = Vector2.MoveTowards(_myTransform.position, _startposition, _speed * Time.deltaTime);
                if (_myTransform.position.y >= _startposition.y && _myTransform.position.x >= _startposition.x)
                {
                    _isreturning = false;
                }

            }
        }
    }
}
