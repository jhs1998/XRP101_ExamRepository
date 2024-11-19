using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    [field: Range(0, 100)]
    public int Hp { get; private set; }

    [SerializeField] GameObject player;
    [SerializeField] AudioSource _audio;

    private void Awake()
    {
        //Init();
    }

    private void Init()
    {
        _audio = GetComponent<AudioSource>();
    }
    
    public void TakeHit(int damage)
    {
        Hp -= damage;
        Debug.Log($"�÷��̾�� {damage}������");
        Debug.Log($"���� ü�� {Hp}");
        if (Hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        _audio.Play();
        Destroy(player, 1f);
        gameObject.SetActive(false);
    }
}
