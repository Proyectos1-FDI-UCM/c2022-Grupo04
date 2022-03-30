using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBox : MonoBehaviour
{
    #region properties
    [SerializeField]
    private GameObject myBox;
    [SerializeField]
    private Transform _boxSpawnPos;
    public List<GameObject> _listOfBoxes;
    #endregion

    #region reference
    private Transform _myTransfrom;
    private GroundCheck _myGroundCheck;
    private UIManager _UIManager;
    private GameManager _gameManager;
    #endregion

    #region parameters
    //private int boxNum = 0;
    private int boxMax = 4;
    #endregion


    // Instantiate a box when we press space key
    public void Box()
    {
        if (_myGroundCheck.IsGrounded())
        {
            GameObject newObject = Instantiate(myBox, _boxSpawnPos.position, _myTransfrom.rotation) as GameObject; //mejor con array activando y desactivando para no perder memoria
            _listOfBoxes.Add(newObject);
            //boxNum++;
            _gameManager.m_boxesCount++;
           // _UIManager.showBoxes(_gameManager.m_boxesCount);
            if (_gameManager.m_boxesCount == boxMax) RemoveBox();
            
        } 
    }   
    public void RemoveBox()
    {
        if(_gameManager.m_boxesCount >= 1)
        {
            GameObject gameObjectToRemove = _listOfBoxes[0];
            _listOfBoxes.Remove(gameObjectToRemove);
            Destroy(gameObjectToRemove);
            _gameManager.m_boxesCount--;
        }
    }
   

    void Start()
    {
        _myTransfrom = transform;
        _myGroundCheck = GetComponentInChildren<GroundCheck>();
    }

    private void Awake()
    {
        _listOfBoxes = new List<GameObject>();
    }



}
