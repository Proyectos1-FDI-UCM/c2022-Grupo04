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
        if (collision.collider.GetComponent<Rigidbody2D>() != null)
            collision.rigidbody.velocity = m_direction * Vector2.right * m_speed * Time.deltaTime;
    }
    #endregion
}