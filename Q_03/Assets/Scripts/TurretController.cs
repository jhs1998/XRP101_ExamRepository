using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    // 발사 포인트
    [SerializeField] private Transform _muzzlePoint;
    // 총알 오브젝트
    [SerializeField] private CustomObjectPool _bulletPool;
    // 발사 텀
    [SerializeField] private float _fireCooltime;

    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private void Awake()
    {
        Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Fire(other.transform);
        }
    }

    private void Init()
    {
        _coroutine = null;
        _wait = new WaitForSeconds(_fireCooltime);
        _bulletPool.CreatePool();
    }

    private IEnumerator FireRoutine(Transform target)
    {
        while (true)
        {
            // 생성 후 플레이어가 소멸할 경우 추가
            if (target != null)
            {
                yield return _wait;

                transform.rotation = Quaternion.LookRotation(new Vector3(
                    target.position.x,
                    0,
                    target.position.z)
                );
                // 탄환 잔탄이 없을 경우 안쏘게 해줌
                PooledBehaviour bullet = _bulletPool.TakeFromPool();
                if (bullet != null)
                {
                    bullet.transform.position = _muzzlePoint.position;
                    bullet.OnTaken(target);
                }
                else
                {
                    Debug.Log("총알 부족");
                }
                // 총알 갯수를 늘려도 5번째 총알부터 가속하는 문제는 해결이 안됨..
                // 총알이 점차 2배씩 빨라지는 느낌이라 총알의 힘이 제거가 안되고 중첩되는듯?
            }
            else
            {
                // 플레이어가 없으면 종료
                Debug.Log("플레이어 없음");
                yield break;
            }
        }
    }

    private void Fire(Transform target)
    {       
        _coroutine = StartCoroutine(FireRoutine(target));
    }
}
