using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    public float Score { get; set; }

    // �� ���۸��� �ʱ�ȭ ��
    private void Awake()
    {
        SingletonInit();
        // ���ھ ó�� ���̵��ÿ��� 0.1�� �����ǰ� �ؾߵ�
        if (Score == 0)
        {
            Score = 0.1f;
        }
        // ��....
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
