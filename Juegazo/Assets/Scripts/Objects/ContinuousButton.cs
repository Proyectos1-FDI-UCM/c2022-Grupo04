using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousButton : MonoBehaviour
{
    #region properties
    private enum ButtonType { Belt, Plataform }
    [SerializeField]
    private ButtonType _type;
    #endregion

    #region references
    [SerializeField]
    private GameObject[] _attachedObject;
    #endregion

    #region methods
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Rigidbody2D>() != null)
        {
            if (_type == ButtonType.Belt)
            {
                for (int i = 0; i < _attachedObject.Length; i++)
                    _attachedObject[i].GetComponent<BeltStateManager>().Active();
            }
            else
            {
                for (int i = 0; i < _attachedObject.Length; i++)
                    _attachedObject[i].GetComponent<PlataformStateManager>().FinalState();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Rigidbody2D>() != null)
        {
            if (_type == ButtonType.Belt)
            {
                for (int i = 0; i < _attachedObject.Length; i++)
                    _attachedObject[i].GetComponent<BeltStateManager>().Disabled();
            }
            else
            {
                for (int i = 0; i < _attachedObject.Length; i++)
                    _attachedObject[i].GetComponent<PlataformStateManager>().InitialState();
            }
        }
    }
    #endregion
}
