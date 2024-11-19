using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    [SerializeField] private float _deactiveTime;
    private WaitForSeconds _wait;
    private Button _popupButton;

    [SerializeField] private GameObject _popup;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _popupButton = GetComponent<Button>();
        SubscribeEvent();
    }

    private void SubscribeEvent()
    {
        _popupButton.onClick.AddListener(Activate);
        Debug.Log("ÀÌº¥Æ® ÀÛµ¿1");
    }

    private void Activate()
    {
        _popup.gameObject.SetActive(true);
        Debug.Log("ÆË¾÷ ¶ç¿ì±â");
        GameManager.Intance.Pause();
        Debug.Log("ÆË¾÷ ¶ç¿ì±â2");
        StartCoroutine(DeactivateRoutine());
    }

    private void Deactivate()
    {
        _popup.gameObject.SetActive(false);
        Debug.Log("ÆË¾÷ Á¦°Å");
    }

    private IEnumerator DeactivateRoutine()
    {
        yield return new WaitForSecondsRealtime(_deactiveTime);
        Debug.Log("2ÃÊ ´ë±â");
        Deactivate();
    }
}
