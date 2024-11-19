using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private float playerMoveSpeed;
    // MoveSpeed 가 있는데 안에서 또 참조하니까 무한굴레에 빠지게됨
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
