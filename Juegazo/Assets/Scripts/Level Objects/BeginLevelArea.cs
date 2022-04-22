using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginLevelArea : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject _pared;

    #endregion

    #region methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.m_changeLevel)
        {
            if (collision.GetComponent<PlayerLifeComponent>() != null)
            {
                collision.GetComponent<InputManager>().enabled = true;
                GameManager.Instance.InicioNivel();
                _pared.SetActive(true);
            }
        }
        
    }
    #endregion
}
