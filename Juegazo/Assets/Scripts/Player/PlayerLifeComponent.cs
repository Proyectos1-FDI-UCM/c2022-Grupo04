using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeComponent : MonoBehaviour
{
    #region methods
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<EnemyLifeComponent>() != null || collision.collider.GetComponent<Damage>() != null)
            Die();
    }

    public void Die()
    {
        GameManager.Instance.OnPlayerDies();
        Destroy(gameObject);
    }
    #endregion
}
