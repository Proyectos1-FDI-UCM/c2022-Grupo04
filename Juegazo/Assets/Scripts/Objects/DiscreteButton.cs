using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscreteButton : MonoBehaviour
{
    #region properties
    private enum ButtonType { Belt, Plataform, Lift }
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
        if (collision.collider.GetComponent<EnemyThere>() != null)
        {
            if (_type == ButtonType.Belt)
            {
                for (int i = 0; i < _attachedObject.Length; i++)
                    _attachedObject[i].GetComponent<BeltStateManager>().Active();
            }
            else if (_type==ButtonType.Plataform)
            {
                for (int i = 0; i < _attachedObject.Length; i++)
                    _attachedObject[i].GetComponent<PlataformStateManager>().Move();
            }
            else if (_type==ButtonType.Lift)
            {
                for (int i = 0; i < _attachedObject.Length; i++)
                    _attachedObject[i].GetComponent<Lift>().Move();
            }

        }
    }
    #endregion
}
