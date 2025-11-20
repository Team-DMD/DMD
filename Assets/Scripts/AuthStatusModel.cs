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

    private void OnEnable()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(1f, 0.8f);
    }

    public void OnLogin(bool flag)
    {
        if (flag)
        {
            statusText.text = "로그인 성공!";
            statusDescription.text = "성공적으로 로그인하여 DMD 세계를 즐길 준비가 되었습니다!";
        }
        else
        {
            statusText.text = "로그인 실패..";
            statusDescription.text = "문제가 발생하였습니다.. 비밀번호가 맞는지 확인하시고 관리자에게 문의하세요..";
        }
        gameObject.SetActive(true);
    }

    public void OnRegister(bool flag)
    {
        if (flag)
        {
            statusText.text = "회원가입 성공!";
            statusDescription.text = "성공적으로 로그인하여 DMD 세계를 즐길 준비가 되었습니다!";
        }
        else
        {
            statusText.text = "회원가입 실패..";
            statusDescription.text = "문제가 발생하였습니다.. 비밀번호가 맞는지 확인하시고 관리자에게 문의하세요..";
        }
        gameObject.SetActive(true);
    }

    public void OnClick()
    {
        transform.DOScale(0f, 0.3f)
            .OnComplete(() => 
            {
                onConfirm?.Invoke();
                gameObject.SetActive(false);
            });
        
    }
    
}