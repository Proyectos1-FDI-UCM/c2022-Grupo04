using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    #region references
    private Transform _myTransform;
    #endregion

    #region properties
    [SerializeField]
    private float _speed;
    private Vector2 _direction = new Vector2(0,0);
    #endregion

    #region methods
    public void SetCameraDirection(Vector2 direction)
    {
        _direction = direction;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _myTransform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void Awake()
    {
        this.enabled = false;
    }
}
