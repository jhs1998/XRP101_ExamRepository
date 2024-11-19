using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotater : MonoBehaviour
{
    private bool isSpin = true; // È¸ÀüÇÏ´Â°Å ¸ØÃã
    private void Update()
    {
        if (isSpin)
        {
            transform.Rotate(Vector3.up * GameManager.Intance.Score);
        }           
    }
    public void Pause()
    {
        isSpin = false; // È¸Àü Á¾·á
    }

    public void RePause()
    {
        isSpin = true; // È¸Àü ¸ØÃã
    }
}
