using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    private Transform _myplayer;
    [SerializeField]
    private Transform _myTransform;
    [SerializeField]
    private Vector2 _initialPos;
    [SerializeField]
    private Vector2 _finalPos;
    [SerializeField]
    private float speed;
    bool isdown;

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _myTransform.position = _initialPos;
    }

    // Update is called once per frame
    void Update()
    {
        StartElevator();
    }

    void StartElevator()
    {
        
        if (transform.position.y <= _finalPos.y)
        {
            isdown = true;
        }
        else if (transform.position.y >= _initialPos.y)
        {
            isdown = false;
        }

        if (isdown)
        {
            transform.position = Vector2.MoveTowards(transform.position, _initialPos, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _finalPos, speed * Time.deltaTime);
        }
    }
}
