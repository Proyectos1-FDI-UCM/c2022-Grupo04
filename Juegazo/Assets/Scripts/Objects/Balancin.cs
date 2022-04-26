using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balancin : MonoBehaviour
{
    private float _elapsedTime;
    private bool a;
    [SerializeField]
    private float _restarttime;
    private Transform _mytransform;
   
    private void OnCollisionExit2D(Collision2D collision)
    {
        PlayerLifeComponent _playerLife;
        _playerLife = collision.collider.GetComponent<PlayerLifeComponent>();
        if (_playerLife != null)
        {
            Debug.Log("Balancín");
            a = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        a = false;
        _mytransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (a)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _restarttime)
            {
                _mytransform.rotation = Quaternion.Euler(0, 0, 0);
                _elapsedTime = 0;
                a = false;
            }
        }
    }
}
