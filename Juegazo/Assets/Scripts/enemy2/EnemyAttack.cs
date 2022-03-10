using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    #region methods
    private void OnTriggerEnter2D(Collider2D collision) //es un trigger :)
    {
        InputManager _inputMovement;
        _inputMovement = collision.GetComponent<InputManager>();
        if (_inputMovement != null)
        {
            GetComponentInParent<EnemyDirection>().enabled = false;
            GetComponentInParent<EnemyGrounded>().enabled = false;
            GetComponentInParent<EnemyFollow>().enabled = true;    //se desactiva el movimiento random del enemigo para que siga al jugador
        }
    }
    #endregion


}
