using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornillos : MonoBehaviour
{
    #region methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        InputManager _inputManager;
        _inputManager = collision.GetComponent<InputManager>();
        if (_inputManager != null)
        {
            GameManager.Instance.m_tornilloCount++;
            Debug.Log(GameManager.Instance.m_tornilloCount);
            Destroy(gameObject); //asi?
            _pared.SetActive(false);
           
            //esta activacion en verdad se hace con el trigger de inicia nive



        }
    }
    #endregion

    #region parameters
    [SerializeField]
    private int numTornillos;
    #endregion

    #region references
    [SerializeField]
    private GameObject _pared;
    #endregion
}
