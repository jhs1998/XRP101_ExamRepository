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
        Debug.Log("�̺�Ʈ �۵�1");
    }

    private void Activate()
    {
        _popup.gameObject.SetActive(true);
        Debug.Log("�˾� ����");
        GameManager.Intance.Pause();
        Debug.Log("�˾� ����2");
        StartCoroutine(DeactivateRoutine());
    }

    private void Deactivate()
    {
        _popup.gameObject.SetActive(false);
        Debug.Log("�˾� ����");
    }

    private IEnumerator DeactivateRoutine()
    {
        yield return new WaitForSecondsRealtime(_deactiveTime);
        Debug.Log("2�� ���");
        Deactivate();
    }
}
