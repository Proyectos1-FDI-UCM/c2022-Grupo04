using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    #region references
    SpriteRenderer _mySpriteRenderer;
    #endregion

    #region methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<InputManager>() != null)
        {
            Debug.Log("choquesito");
            _mySpriteRenderer.enabled = true;
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        _mySpriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
