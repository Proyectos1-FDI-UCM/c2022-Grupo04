using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLimitDown : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject _player;
    private RobotBox _playerRobotBox;
    private PlayerLifeComponent _playerLife;
    #endregion

    #region methods
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyThere _enemyThere;
        _enemyThere = collision.collider.GetComponent<EnemyThere>();
        PlayerLifeComponent _playerLifeComponent = collision.collider.GetComponentInParent<PlayerLifeComponent>();
        if (_enemyThere != null )
        {
            GameManager.Instance.m_boxesCount--;
            _playerRobotBox._listOfBoxes.Remove(collision.collider.gameObject);
            Destroy(collision.collider.gameObject);
        }
        if(_playerLifeComponent != null)
        {
            Debug.LogError("lol");
            _playerLife.Die();
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _playerRobotBox = _player.GetComponent<RobotBox>();
        _playerLife = _player.GetComponent<PlayerLifeComponent>();
    }
}
