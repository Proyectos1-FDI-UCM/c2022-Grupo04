using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyDirection : MonoBehaviour
{
    #region references
    private CharacterMovement _myCharacterMovement;
    private Transform _myTransform;
    #endregion

    #region parameters
    private Vector2 _direction;
    #endregion

    #region properties
    private float _elapsedTime = 0f;
    [SerializeField]
    private float _timeNewDirection = 5f;
    [SerializeField]
    private float _enemyMovementSpeed = 2.0f;
    #endregion

    #region methods
    private Vector2 SetRandomMovement()
    {
        Vector2 newDirection = new Vector2(0,0);
        newDirection.x = Random.Range(0, 2);
        if (newDirection.x == 1)
            SetRandomRotation();
        return newDirection;
    }

    private void SetRandomRotation()
    {
        if(Random.Range(0,2) == 1)
            _myTransform.Rotate(0, 180, 0);
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myCharacterMovement = GetComponent<CharacterMovement>();
        _myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        
        if(_elapsedTime >= _timeNewDirection)
        {
            _direction = SetRandomMovement();
            _myCharacterMovement.SetDirection(_direction, _enemyMovementSpeed);
            _elapsedTime = 0f;
        }
    }
}