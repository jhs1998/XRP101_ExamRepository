using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    // 큐브 프리펩
    [SerializeField] private GameObject _cubePrefab;
    // 큐브 컨트롤러 참조
    private CubeController _cubeController;
    // 큐브 좌표
    private Vector3 _cubeSetPoint;

    private void Awake()
    {
        // 큐브 생성
        CreateCube();       
    }

    private void Start()
    {
        SetCubePosition(3, 0, 3);
    }

    // 생성이 안되었는데 큐브 컨트롤러를 참조하여 오류
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
