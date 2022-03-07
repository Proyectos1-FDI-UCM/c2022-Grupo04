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

        if (_myCharacterMovement.m_movementDirection.x != 0)
            newDirection.x = Random.Range(0, 2);
        else
            newDirection.x = 1;

        if (newDirection.x == 1)
            SetRandomRotation();
        return newDirection;
    }

    private void SetRandomRotation()
    {
        if(Random.Range(0,2) == 1)
            _myTransform.Rotate(0, 180, 0);
    }

    private void WallDetection()
    {
        if (Physics2D.Raycast(_myTransform.position, _myTransform.right, 1, _myLayerMask))
        {
            Debug.Log("Sí");
            _myTransform.Rotate(0, 180, 0); 
        }
        Debug.DrawRay(_myTransform.position, _myTransform.right);
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
