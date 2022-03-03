using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrounded : MonoBehaviour
{
    #region references
    private CharacterMovement _enemyCharacterMovement;
    private static Transform _myTransform;
    private static Transform _enemyTransform;
    private static LayerMask _plataformLayer;
    #endregion

    #region methods
    static bool IsGrounded()
    {
        bool grounded = true;

        RaycastHit2D hit = Physics2D.Raycast(_myTransform.position, Vector2.down, 2f, _plataformLayer);

        if (hit.collider == null)
            grounded = false;

        return grounded;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _enemyCharacterMovement = GetComponentInParent<CharacterMovement>();
        _myTransform = transform;
        _enemyTransform = transform.parent;
        _plataformLayer = LayerMask.GetMask("Platform");
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGrounded())
            _enemyTransform.Rotate(0, 180, 0);
    }
}
