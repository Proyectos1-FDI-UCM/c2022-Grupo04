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
    #region methods
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
