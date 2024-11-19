using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotater : MonoBehaviour
{
    private bool isSpin = true; // ȸ���ϴ°� ����
    private void Update()
    {
        if (isSpin)
        {
            transform.Rotate(Vector3.up * GameManager.Intance.Score);
        }           
    }
    public void Pause()
    {
        isSpin = false; // ȸ�� ����
    }

    public void RePause()
    {
        isSpin = true; // ȸ�� ����
    }
}
