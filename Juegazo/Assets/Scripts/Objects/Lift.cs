using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    #region references
    private Vector2 _startposition;
    [SerializeField]
    private float _distance;
    private Vector2 _finalposition;
    private Transform _myTransform;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Vector2 _initialdirection;
    private Vector2 _direction;
    private bool _isrunning;
    private bool _isreturning;

    #endregion

 
    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _direction = _initialdirection;
        _isrunning = false;
        _startposition = _myTransform.position;
        _finalposition = _startposition + (_distance * _direction); //se calcula la posicion final segun el rango que queramos y direccion
    }

    // Update is called once per frame
    void Update()
    {
        if (_isrunning)
        {
            _myTransform.position = Vector2.MoveTowards(_myTransform.position, ((Vector2)_myTransform.position+_direction), _speed * Time.deltaTime);
            if (_initialdirection.y==1)
            {
                if (_direction.y==1&& _myTransform.position.y >= _finalposition.y)
                {
                        _direction.y = _direction.y*-1;
                
                }
                else if(_direction.y==-1&&_myTransform.position.y<=_startposition.y)
                {
                        _direction.y = _direction.y*-1;
                 
                }
            }
            else if (_initialdirection.y==-1)
            {
                if (_direction.y == -1 && _myTransform.position.y <= _finalposition.y)
                {
                    _direction.y = _direction.y * -1;

                }
                else if (_direction.y == 1 && _myTransform.position.y >= _startposition.y)
                {
                    _direction.y = _direction.y * -1;

                }
            }
            
        }
        if (_isreturning)
        {
            if (_initialdirection.y == 1)
            {
            _myTransform.position = Vector2.MoveTowards(_myTransform.position, _startposition, _speed * Time.deltaTime);
                if (_myTransform.position.y <= _startposition.y)
                    _isreturning = false;
            }
            else
            {
            _myTransform.position = Vector2.MoveTowards(_myTransform.position, _startposition, _speed * Time.deltaTime);
                if (_myTransform.position.y >= _startposition.y)
                    _isreturning = false;
            }
        }
        
       
        




    }
    public void Move()
    {
        _isrunning = true;
    }
    public void Stop()
    {
        _isrunning = false;
        _isreturning = true;
    }

}

