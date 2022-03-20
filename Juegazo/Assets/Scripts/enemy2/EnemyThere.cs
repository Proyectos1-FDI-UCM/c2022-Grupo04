using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThere : MonoBehaviour
{

    Rigidbody2D _myRigidBody;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Rigidbody2D>() != null)
        {
            _myRigidBody.velocity = _myRigidBody.velocity.normalized;
        }
    }

    private void Start()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
    }
}
