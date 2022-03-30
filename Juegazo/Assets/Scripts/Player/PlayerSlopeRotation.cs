using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlopeRotation : MonoBehaviour
{
    #region parameters
    private Transform _myTransform;
    private float _maxRotation = 50;
    #endregion

    #region methods
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            Debug.Log("chocao con cuestita");
            _myTransform.rotation = Quaternion.RotateTowards(_myTransform.rotation, collision.transform.rotation, _maxRotation);
        }

        else
        {
            _myTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
    }
}
