using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeComponent : MonoBehaviour
{
    #region methods
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Damage>() != null)
            Die();
    }
    public void Die()
    {
        Destroy(gameObject);
    }

    #endregion
}
