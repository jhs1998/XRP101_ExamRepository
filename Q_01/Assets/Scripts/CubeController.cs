using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Vector3 SetPoint { get; private set; }

    // ���� �޾ƿü��ְ� Vector3 SetPoint �߰�
    public void SetPosition(Vector3 SetPoint)
    {
        // ���ӿ�����Ʈ �߰�
        Debug.Log($"{SetPoint}");
        gameObject.transform.position = SetPoint;
    }
}
