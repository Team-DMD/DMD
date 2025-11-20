using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AuthStatusModel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private TextMeshProUGUI statusDescription;
    [SerializeField] private Button confirmButton;
    
    public event Action onConfirm;
    public event Action onSuccess;

    private void OnEnable()
    {
        transform.position = new Vector3(0,-3.5f,0);
        transform.DOMove(new Vector3(0,-0.5f,0), 0.4f);
        transform.localScale = Vector3.zero;
        transform.DOScale(1f, 0.4f);
    }

    public void OnLogin(int code)
    {
        if (code/100==2)
        {
            statusText.text = "로그인 성공!";
            statusDescription.text = "성공적으로 로그인하여 DMD 세계를 즐길 준비가 되었습니다!";
            onConfirm += onSuccess;
        }
        else
        {
            statusText.text = "로그인 실패..";
            statusDescription.text = StateCodeTranslator.Translate(code);
            onConfirm -= onSuccess;
        }
        gameObject.SetActive(true);
    }

    public void OnRegister(int code)
    {
        if (code/100==2)
        {
            statusText.text = "회원가입 성공!";
            statusDescription.text = "성공적으로 로그인하여 DMD 세계를 즐길 준비가 되었습니다!";
            onConfirm += onSuccess;
        }
        else
        {
            statusText.text = "회원가입 실패..";
            statusDescription.text = StateCodeTranslator.Translate(code);
            onConfirm -= onSuccess;
        }
        gameObject.SetActive(true);
    }

    public void OnClick()
    {
        transform.DOMove(new Vector3(0,-3.5f,0), 0.3f);
        transform.DOScale(0f, 0.3f)
            .OnComplete(() => 
            {
                onConfirm?.Invoke();
                gameObject.SetActive(false);
            });
        
    }
    
}