using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    // �߻� ����Ʈ
    [SerializeField] private Transform _muzzlePoint;
    // �Ѿ� ������Ʈ
    [SerializeField] private CustomObjectPool _bulletPool;
    // �߻� ��
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
            // ���� �� �÷��̾ �Ҹ��� ��� �߰�
            if (target != null)
            {
                yield return _wait;

                transform.rotation = Quaternion.LookRotation(new Vector3(
                    target.position.x,
                    0,
                    target.position.z)
                );
                // źȯ ��ź�� ���� ��� �Ƚ�� ����
                PooledBehaviour bullet = _bulletPool.TakeFromPool();
                if (bullet != null)
                {
                    bullet.transform.position = _muzzlePoint.position;
                    bullet.OnTaken(target);
                }
                else
                {
                    Debug.Log("�Ѿ� ����");
                }
                // �Ѿ� ������ �÷��� 5��° �Ѿ˺��� �����ϴ� ������ �ذ��� �ȵ�..
                // �Ѿ��� ���� 2�辿 �������� �����̶� �Ѿ��� ���� ���Ű� �ȵǰ� ��ø�Ǵµ�?
            }
            else
            {
                // �÷��̾ ������ ����
                Debug.Log("�÷��̾� ����");
                yield break;
            }
        }
    }

    private void Fire(Transform target)
    {       
        _coroutine = StartCoroutine(FireRoutine(target));
    }
}
