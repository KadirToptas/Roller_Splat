using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject[] grounds;

    public float groundNumbers;

    private int _currentLevel;
    void Start()
    {
        grounds = GameObject.FindGameObjectsWithTag("Ground");
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    
    void Update()
    {
        groundNumbers = grounds.Length;
    }

    public void LevelUpdate()
    {
        SceneManager.LoadScene(_currentLevel + 1);
    }
}
