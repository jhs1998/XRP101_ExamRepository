using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    [SerializeField] private float _deactiveTime;
    [SerializeField] GameObject cube;
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
        Debug.Log("이벤트 작동1");
    }

    private void Activate()
    {
        _popup.gameObject.SetActive(true);
        Debug.Log("팝업 띄우기");
        cube.GetComponent<ObjectRotater>().Pause();
        //GameManager.Intance.Pause();
        StartCoroutine(DeactivateRoutine());
    }

    private void Deactivate()
    {
        _popup.gameObject.SetActive(false);
        cube.GetComponent<ObjectRotater>().RePause();
        Debug.Log("팝업 제거");
    }

    private IEnumerator DeactivateRoutine()
    {
        yield return new WaitForSecondsRealtime(_deactiveTime);
        Debug.Log("2초 대기");
        Deactivate();
    }
}
