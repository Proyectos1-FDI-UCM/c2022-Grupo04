using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region paramters
    [SerializeField]
    private GameObject ShowTime;
    private Text _timeText;
    [SerializeField]
    private GameObject ShowTornillos;
    private Text _tornillosText;
    [SerializeField]
    private Sprite _imagentornillo;
    #endregion
<<<<<<< HEAD
    #region methods
=======

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
>>>>>>> parent of fb9b243 (UI and Scene Management)
    public void showTimer(float Timeleft)
    {
        _timeText.text = "Time: " + (int)Timeleft;
    }
    public void showTornillos(int tornillocount)
    {
        _tornillosText.text = "x" + tornillocount;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _timeText = ShowTime.GetComponent<Text>();
        _tornillosText = ShowTornillos.GetComponent<Text>();
<<<<<<< HEAD
=======
        _myImage.enabled = false;
        _myPanel.SetActive(false);
>>>>>>> parent of fb9b243 (UI and Scene Management)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
