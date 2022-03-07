using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeComponent : MonoBehaviour
{
    #region methods
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<EnemyLifeComponent>() != null || collision.collider.GetComponent<Damage>() != null)
            GameManager.Instance.OnPlayerDies();
    }

    private void Die()
    {
        Destroy(gameObject);

    }
    #endregion
}
