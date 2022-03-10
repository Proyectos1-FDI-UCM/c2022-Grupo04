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
    private Image _imagentornillo;
    [SerializeField]
    private GameObject _levelObject;
    private Text _levelText;
    #endregion

    #region references
    [SerializeField]
    public GameObject _myPanel;
    [SerializeField]
    private Canvas _myCanvas;
    [SerializeField]
    private Image _myControls;
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
        _myControls.enabled = true;
    }
    public void showTimer(float Timeleft)
    {
        _timeText.text = "Time: " + (int)Timeleft;
    }
    public void showTornillos(int tornillocount)
    {
        _tornillosText.text = "x" + tornillocount;
    }

    public void showLevel(int level)
    {
        _levelText.text = "Level: " + level;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _timeText = ShowTime.GetComponent<Text>();
        _tornillosText = ShowTornillos.GetComponent<Text>();
        _myControls.enabled = false;
        _myPanel.SetActive(false);
        _levelText = _levelObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _myControls.enabled == true)
        {
            _myPanel.SetActive(true);
            _myControls.enabled = false;
        }
    }
}
