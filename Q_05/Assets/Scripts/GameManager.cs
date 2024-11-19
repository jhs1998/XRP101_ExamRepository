using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    public float Score { get; set; }

    private void Awake()
    {
        SingletonInit();
        Score = 0.1f;
    }

    public void Pause()
    {
        Debug.Log("����!");
        Time.timeScale = 0f;
    }

    public void LoadScene(int buildIndex)
    {
        Debug.Log("����");
        SceneManager.LoadScene(buildIndex);
    }
}
