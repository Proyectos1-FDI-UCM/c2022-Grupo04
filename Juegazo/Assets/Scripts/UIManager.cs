using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region references
    [SerializeField]
    public GameObject _myPanel;
    [SerializeField]
    private Canvas _myCanvas;
    [SerializeField]
    private Image _myImage;
    #endregion

    #region methods
    public void Pause()
    {
        _myPanel.SetActive(true);
        GameManager.Instance.Pause();
    }
    public void Continue()
    {
        _myPanel.SetActive(false);
        GameManager.Instance.Continue();
    }
    public void MainMenu()
    {
        _myPanel.SetActive(false);           //probably no hace falta pero idk
        GameManager.Instance.MainMenu();
    }
    public void Quit()
    {
        _myPanel.SetActive(false);
        GameManager.Instance.Quit();
    }
    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }
    public void Controls()
    {
        _myPanel.SetActive(false);
        _myImage.enabled = true;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myImage.enabled = false;
        _myPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _myImage.enabled == true)
        {
            _myPanel.SetActive(true);
            _myImage.enabled = false;
        }
    }
}
