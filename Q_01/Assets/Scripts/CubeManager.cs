using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    // ť�� ������
    [SerializeField] private GameObject _cubePrefab;
    // ť�� ��Ʈ�ѷ� ����
    private CubeController _cubeController;
    // ť�� ��ǥ
    private Vector3 _cubeSetPoint;

    private void Awake()
    {
        // ť�� ����
        CreateCube();       
    }

    private void Start()
    {
        SetCubePosition(3, 0, 3);
    }

    // ������ �ȵǾ��µ� ť�� ��Ʈ�ѷ��� �����Ͽ� ����
    private void SetCubePosition(float x, float y, float z)
    {
        _cubeSetPoint.x = x;
        _cubeSetPoint.y = y;
        _cubeSetPoint.z = z;
        _cubeController.SetPosition(_cubeSetPoint);
    }

    private void CreateCube()
    {
        GameObject cube = Instantiate(_cubePrefab);
        _cubeController = cube.GetComponent<CubeController>();
        _cubeSetPoint = _cubeController.SetPoint; // 0,0,0
    }
}
