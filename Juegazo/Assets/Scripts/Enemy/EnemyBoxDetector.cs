using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoxDetector : MonoBehaviour
{
    #region references
    private Transform _myTransform;
    private LayerMask _myLayer;
    private EnemyLifeComponent _myEnemyLifeComponent;
    #endregion

    #region methods
    public void BoxDetected()
    {
        if (Physics2D.Raycast(_myTransform.position, Vector2.up, 0.3f, _myLayer))
        {
            Debug.Log("Caja");
            _myEnemyLifeComponent.Die();
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _myEnemyLifeComponent = GetComponentInParent<EnemyLifeComponent>();
        _myLayer = LayerMask.GetMask("Box");
    }

    // Update is called once per frame
    void Update()
    {
        BoxDetected();
    }
}
