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
    static private GameManager _instance;
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
    }

    public void OnPlayerDies()
    {
        SceneManager.LoadScene(0);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("level", m_currentLevel);
    }

    private void Load()
    {
        m_currentLevel = PlayerPrefs.GetInt("level", m_currentLevel);
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _instance = this;

        _camera = Camera.main.gameObject;
        _cameraMovement = _camera.GetComponent<CameraMovement>();
        _playerInput = _player.GetComponent<InputManager>();

        _levelText = _levelObject.GetComponent<Text>();
        _levelText.text = "Level: " + m_currentLevel;
        _player.transform.position = _beginLevelArea[m_currentLevel - 1].position;
        _camera.transform.position = _posCamera[m_currentLevel - 1].position;
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
}