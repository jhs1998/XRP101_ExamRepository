using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Vector3 SetPoint { get; private set; }

    // 값을 받아올수있게 Vector3 SetPoint 추가
    public void SetPosition(Vector3 SetPoint)
    {
        // 게임오브젝트 추가
        Debug.Log($"{SetPoint}");
        gameObject.transform.position = SetPoint;
    }
}
