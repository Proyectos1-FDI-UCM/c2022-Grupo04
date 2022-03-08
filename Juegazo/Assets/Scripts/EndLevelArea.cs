using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelArea : MonoBehaviour
{
    #region methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerLifeComponent>() != null)
        {
            if(GameManager.Instance.m_tornilloCount == GameManager.Instance.m_currentLevel)
            {
                GameManager.Instance.m_currentLevel++;
                GameManager.Instance.ChangeLevel();
            }  
        }
    }
    #endregion
}
