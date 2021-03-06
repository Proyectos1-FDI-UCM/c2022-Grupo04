using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDirection : MonoBehaviour
{
    #region references
    private CharacterMovement _myCharacterMovement;
    private Transform _myTransform;
    private LayerMask _myLayerMask;
    #endregion

    #region parameters
    private Vector2 _direction;
    #endregion

    #region properties
    private float _elapsedTime = 0f;
    [SerializeField]
    private float _timeNewDirection = 1f;
    #endregion

    #region methods
    private Vector2 SetRandomMovement()
    {
        Vector2 newDirection = new Vector2(0,0);
        int prb = 0;

        if (_myCharacterMovement.m_movementDirection.x != 0)
            prb = Random.Range(0, 2);
        else
        {
            newDirection = new Vector2(1, 0);
            newDirection = SetRandomRotation(newDirection);
            prb = 2;
        }

        if (prb == 1)
            newDirection = SetRandomRotation(newDirection);
        else if(prb == 0)
            newDirection = new Vector2(0, 0);

        return newDirection;
    }

    private Vector2 SetRandomRotation(Vector2 dir)
    {
        Vector2 aux;

        if (Random.Range(0, 2) == 1)
            aux = dir * -1;
        else
            aux = dir;

        return aux;
    }

    private void WallDetection()
    {
        if (Physics2D.Raycast(_myTransform.position,new Vector2(_myTransform.localScale.x, 0), 1, _myLayerMask))
        {
            Debug.Log("S?");
            _myCharacterMovement.SetDirection(_myCharacterMovement.m_movementDirection * -1);
        }
        Debug.DrawRay(_myTransform.position, new Vector2(_myTransform.localScale.x, 0));
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myCharacterMovement = GetComponent<CharacterMovement>();
        _myTransform = transform;
        _myLayerMask = LayerMask.GetMask("Plataform");
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;

        WallDetection();

        if(_elapsedTime >= _timeNewDirection)
        {
            _direction = SetRandomMovement();
            _myCharacterMovement.SetDirection(_direction);
            _elapsedTime = 0f;
        }
    }
}
