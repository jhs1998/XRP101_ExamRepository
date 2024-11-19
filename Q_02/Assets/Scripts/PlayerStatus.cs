using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private float playerMoveSpeed;
    // MoveSpeed �� �ִµ� �ȿ��� �� �����ϴϱ� ���ѱ����� �����Ե�
    public float MoveSpeed
    {
        get => playerMoveSpeed;
        set
        {
            playerMoveSpeed = value;
        }
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        MoveSpeed = 5f;
    }
}
