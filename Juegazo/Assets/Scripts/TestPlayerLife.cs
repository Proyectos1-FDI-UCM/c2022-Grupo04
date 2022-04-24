using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerLife : MonoBehaviour
{
    private Transform _myTransform;
    [SerializeField]
    private GameObject BeginPos;
    #region methods
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<EnemyLifeComponent>() != null || collision.collider.GetComponent<Damage>() != null)
            Die();
    }

    public void Die()
    {
        _myTransform.position = BeginPos.transform.position;
    }
    #endregion
    void Start()
    {
        _myTransform = transform;
    }
}
