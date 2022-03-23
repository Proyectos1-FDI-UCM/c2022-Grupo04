using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThere : MonoBehaviour
{

    Rigidbody2D _myRigidBody;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<CharacterMovement>() != null)
        {
            _myRigidBody.velocity = _myRigidBody.velocity.normalized;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _myRigidBody.velocity = new Vector2(0, 0);
    }

    private void Start()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
    }
}
