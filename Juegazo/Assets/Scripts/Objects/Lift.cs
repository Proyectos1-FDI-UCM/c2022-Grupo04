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

    #endregion

    #region methods
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerLifeComponent  _playerlifecomponent;
        _playerlifecomponent = collision.collider.GetComponentInParent<PlayerLifeComponent>();
        Debug.Log(_playerlifecomponent);
        if (_playerlifecomponent != null)
        {
            _isrunning = true;
            
        }
            

    }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _direction = _initialdirection;
        _startposition = _myTransform.position;
        _isrunning = false;
        _finalposition = _startposition + (_distance * _direction); //se calcula la posicion final segun el rango que queramos y direccion (queremos que sea un extremo o centro?)
    }

    // Update is called once per frame
    void Update()
    {
        if (_isrunning)
        {
            //_myTransform2.position = Vector2.MoveTowards(_myTransform2.position, _playerposition.position, _enemySpeed * Time.deltaTime); como usar el move towards
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
    }
}

