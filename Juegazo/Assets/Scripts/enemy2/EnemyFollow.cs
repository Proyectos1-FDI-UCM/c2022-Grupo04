using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    #region references
    private CharacterMovement _myCharacterMovement;
    private Transform _myTransform2;
    [SerializeField]
    private GameObject _player;
    private Transform _playerposition;
    #endregion

    #region properties
    [SerializeField]
    private float _enemySpeed = 1f;
    #endregion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyThere _enemyThere;
        _enemyThere = collision.collider.GetComponent<EnemyThere>();
        if (enabled && _enemyThere != null)
            _myCharacterMovement.JumpRequest();
    }
    // Start is called before the first frame update
    void Start()
    {
        _myCharacterMovement = GetComponent<CharacterMovement>();
        _myTransform2 = transform;
        _playerposition = _player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        _myTransform2.position = Vector2.MoveTowards(_myTransform2.position, _playerposition.position, _enemySpeed * Time.deltaTime);
    }
    private void Awake()
    {
        this.enabled = false;
    }
}
