using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCamera : MonoBehaviour
{
    #region methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CameraMovement>() != null)
            collision.GetComponent<CameraMovement>().enabled = false;
    }
    #endregion
}
