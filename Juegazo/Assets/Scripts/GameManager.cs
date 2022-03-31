using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private float InitialTime;
    private float Timeleft;
    [HideInInspector]
    public int m_tornilloCount = 0;
    [HideInInspector]
    public int m_boxesCount = 0;
    #endregion

    #region references
    //private RobotBox _robotBox;
    private GameObject _camera;
    private CameraMovement _cameraMovement;
    [SerializeField]
    private GameObject _player;
    private InputManager _playerInput;
    [SerializeField]
    private GameObject _scenesManager;
    private ScenesManager _myScenesManager;
    static private GameManager _instance;
    [SerializeField]
    private GameObject _canvas;
    private UIManager _myUIManager;

    static public GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion

    #region properties
    [SerializeField]
    private Transform[] _posCamera = new Transform[10];
    [SerializeField]
    private Transform[] _beginLevelArea = new Transform[10];
    [HideInInspector]
    public int m_currentLevel = 1;
    [HideInInspector]
    public bool m_level;
    [HideInInspector]
    public int m_world = 1;
    #endregion

    #region methods
    public void ChangeLevel()
    {
        m_level = false;

        Vector2 cameraDirection = _posCamera[m_currentLevel - 1].position - _posCamera[m_currentLevel - 2].position;
        cameraDirection.Normalize();
        _cameraMovement.enabled = true;
        _cameraMovement.SetCameraDirection(cameraDirection);

        _playerInput.enabled = false;
        _player.GetComponent<CharacterMovement>().SetDirection(new Vector2(1, 0));
    }

    public void OnPlayerDies()
    {
        SceneManager.LoadScene(m_world);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("level", m_currentLevel);
        PlayerPrefs.SetInt("tornillos", m_tornilloCount);
        PlayerPrefs.SetInt("world", m_world);
    }

    public void Load()
    {
        m_currentLevel = PlayerPrefs.GetInt("level", m_currentLevel);
        m_tornilloCount = PlayerPrefs.GetInt("tornillos", m_tornilloCount);
        m_world = PlayerPrefs.GetInt("world", m_world);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Continue()
    {
        Time.timeScale = 1;
    }
    public void MainMenu() //no se si hay que hacer algo aqui de player prefs o algo 
    {
        Time.timeScale = 1;
        _myScenesManager.LoadScene("Main_Menu");
    }
    public void Quit()   //igual con lo de player prefs
    {
        Application.Quit();
    }
    public void StartGame()
    {
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.SetInt("tornillos", 0);
        //PlayerPrefs.SetInt("boxes", 0);
        PlayerPrefs.SetInt("world", 1);
        SceneManager.LoadScene(1);
    }

    private void Timer()
    {
        Timeleft -= Time.deltaTime;
    }
    public void InicioNivel()
    {
        Save();
        _myUIManager.showLevel(m_currentLevel);
        Timeleft = InitialTime;
    }

    private void NextWorld()
    {
        SceneManager.LoadScene(m_world);
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _instance = this;

        _camera = Camera.main.gameObject;
        _cameraMovement = _camera.GetComponent<CameraMovement>();
        _playerInput = _player.GetComponent<InputManager>();
        _myScenesManager = _scenesManager.GetComponent<ScenesManager>();

        Debug.Log(m_world);
        _player.transform.position = _beginLevelArea[m_currentLevel - 1].position;
        _camera.transform.position = _posCamera[m_currentLevel - 1].position;

        //tornillos y tiempo
        Timeleft = InitialTime;
        _myUIManager = _canvas.GetComponent<UIManager>();
    }

    private void Awake()
    {
        Load();
    }
    private void Update()
    {
        if (m_level)
        {
            Timer();

            _myUIManager.showTimer(Timeleft);
            if (Timeleft <= 0)
            {
                _player.GetComponent<PlayerLifeComponent>().Die();
                Timeleft = InitialTime;
            }
            _myUIManager.showTornillos(m_tornilloCount);
            _myUIManager.showBoxes(GameManager.Instance.m_boxesCount);
            _myUIManager.showProgress(m_tornilloCount);
        }
        if(m_currentLevel == 6)
        {
            m_world++;
            NextWorld();
        }
    }
}
