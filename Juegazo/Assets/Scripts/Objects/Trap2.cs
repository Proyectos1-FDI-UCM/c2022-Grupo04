using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyThere _enemyThere;
        PlayerLifeComponent _playerLife;
        _enemyThere = collision.GetComponent<EnemyThere>();
        _playerLife = collision.GetComponent<PlayerLifeComponent>();
        if (_enemyThere != null  || _playerLife != null)
        {
            Destroy(gameObject);
        }
    }
}
