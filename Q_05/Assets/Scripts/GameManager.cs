using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    public float Score { get; set; }

    // 씬 시작마다 초기화 됨
    private void Awake()
    {
        SingletonInit();
        // 스코어가 처음 씬이동시에만 0.1로 지정되게 해야됨
        if (Score == 0)
        {
            Score = 0.1f;
        }
        // 흠....
    }

    public void Pause()
    {
        Debug.Log("멈춰!");
        Time.timeScale = 0f;
    }

    public void LoadScene(int buildIndex)
    {
        Debug.Log("반응");
        SceneManager.LoadScene(buildIndex);
    }
}
