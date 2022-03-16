using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager2 : MonoBehaviour
{
    #region references
    [SerializeField]
    private Canvas _myCanvas;
    [SerializeField]
    private Image _myControls;
    #endregion

    #region methods
    public void LoadGame()
    {
        SceneManager.LoadScene(GameManager.Instance.m_world);
    }
    public void Quit()
    {
        GameManager.Instance.Quit();
    }
    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }
    public void Controls()
    {
        _myControls.enabled = true;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myControls.enabled = false;
        GameManager.Instance.m_level = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _myControls.enabled == true)
        {
            _myControls.enabled = false;
        }
    }
}
