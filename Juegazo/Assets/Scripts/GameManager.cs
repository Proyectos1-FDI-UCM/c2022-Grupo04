using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region references
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
    private Tornillos _tornillos;
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
    private Text _levelText;
    [SerializeField]
    private GameObject _levelObject;
    [HideInInspector]
    public bool m_level;
    #endregion

    #region methods
    public void ChangeLevel()
    {
        Vector2 cameraDirection = _posCamera[m_currentLevel - 1].position - _posCamera[m_currentLevel - 2].position;
        cameraDirection.Normalize();
        _cameraMovement.enabled = true;
        _cameraMovement.SetCameraDirection(cameraDirection);

        _playerInput.enabled = false;
        _player.GetComponent<CharacterMovement>().SetDirection(new Vector2(1, 0));
        _levelText.text = "Level: " + m_currentLevel;

        m_level = false;
        Timeleft = InitialTime;
    }

    public void OnPlayerDies()
    {
        SceneManager.LoadScene(0);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("level", m_currentLevel);
        PlayerPrefs.SetInt("tornillos", m_tornilloCount);
    }

    private void Load()
    {
        m_currentLevel = PlayerPrefs.GetInt("level", m_currentLevel);
        m_tornilloCount = PlayerPrefs.GetInt("tornillos", m_tornilloCount);
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
    public void LoadGame()
    {
        //Aqui lo de cargar la partida guardada idk
    }
    public void Quit()   //igual con lo de player prefs
    {
        Application.Quit();
    }
    public void StartGame()
    {
        Debug.Log("startgame");
        SceneManager.LoadScene(0);
    }
    private void Timer()
    {
        Timeleft -= Time.deltaTime;
    }
    #endregion

    #region parameters
    [SerializeField]
    private float InitialTime;
    private float Timeleft;
    [HideInInspector]
    public int m_tornilloCount = 0;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;

        _camera = Camera.main.gameObject;
        _cameraMovement = _camera.GetComponent<CameraMovement>();
        _playerInput = _player.GetComponent<InputManager>();
        _myScenesManager = _scenesManager.GetComponent<ScenesManager>();

        _levelText = _levelObject.GetComponent<Text>();
        _levelText.text = "Level: " + m_currentLevel;
        _player.transform.position = _beginLevelArea[m_currentLevel - 1].position;
        _camera.transform.position = _posCamera[m_currentLevel - 1].position;

        //tornillos y tiempo
        Timeleft = InitialTime;
        _myUIManager = _canvas.GetComponent<UIManager>();
        _tornillos = _canvas.GetComponent<Tornillos>();

        m_level = true;
    }
    public void InicioNivel()
    {
        Save();
        _levelText.text = "Level: " + m_currentLevel;

    }

    private void Awake()
    {
        Load();
    }
    private void Update()
    {
        if (m_level) Timer();

        _myUIManager.showTimer(Timeleft);
        if (Timeleft <= 0)
        {
            _player.GetComponent<PlayerLifeComponent>().Die();
            Timeleft = InitialTime;
        }
        _myUIManager.showTornillos(m_tornilloCount);
    }
}
