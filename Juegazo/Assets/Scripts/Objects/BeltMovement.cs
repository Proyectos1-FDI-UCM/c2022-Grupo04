using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltMovement : MonoBehaviour
{
    #region parameters
    public float m_speed = 1f;
    public int m_direction = 1;
    #endregion

    #region methods
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<GroundCheck>() != null)
        {
            //collision.collider.GetComponentInParent<Rigidbody2D>().velocity = collision.collider.GetComponentInParent<CharacterMovement>().m_JumpVector + (m_direction * Vector2.right * m_speed * Time.deltaTime);
            collision.collider.GetComponentInParent<Rigidbody2D>().velocity += m_direction * Vector2.right * m_speed;
            //collision.collider.GetComponentInParent<CharacterMovement>().m_JumpVector = new Vector2(0, 0);
        }
        else if (collision.collider.GetComponent<EnemyThere>() != null)
            collision.rigidbody.velocity = m_direction * Vector2.right * m_speed;
    }
    #endregion
}
