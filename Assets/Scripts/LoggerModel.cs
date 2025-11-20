using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoggerModel : MonoBehaviour
{
    [Header("Duration")]
    [SerializeField] private float startTime;
    [SerializeField] private float endTime;
    
    [Header("Login Panel")]
    [SerializeField] private Image loginPanelImage;
    
    [Header("Input Fields")]
    [SerializeField] private Image idInputFieldImage;
    [SerializeField] private Image passwordInputFieldImage;
    
    [Header("Buttons")]
    [SerializeField] private Image loginButtonImage;
    [SerializeField] private Image registerButtonImage;
    
    [Header("Input Field Texts (Placeholder)")]
    [SerializeField] private TextMeshProUGUI idPlaceholderText; 
    [SerializeField] private TextMeshProUGUI passwordPlaceholderText; 
    
    [Header("Button Texts")]
    [SerializeField] private TextMeshProUGUI loginButtonText; 
    [SerializeField] private TextMeshProUGUI registerButtonText; 
    
    
    void Start()
    {
        transform.DOMove(new Vector3(0, -0.5f, 0), startTime);
        transform.localScale = new Vector3(0,0,0);
        transform.DOScale(1f, startTime);
        Color loginPanelColor = loginPanelImage.color;
        loginPanelColor.a = 0.0f;
        loginPanelImage.color = loginPanelColor;

        Color idInputColor = idInputFieldImage.color;
        idInputColor.a = 0.0f;
        idInputFieldImage.color = idInputColor;

        Color passwordInputColor = passwordInputFieldImage.color;
        passwordInputColor.a = 0.0f;
        passwordInputFieldImage.color = passwordInputColor;

        Color loginButtonColor = loginButtonImage.color;
        loginButtonColor.a = 0.0f;
        loginButtonImage.color = loginButtonColor;

        Color registerButtonColor = registerButtonImage.color;
        registerButtonColor.a = 0.0f;
        registerButtonImage.color = registerButtonColor;
        
        idPlaceholderText.color = new Color(idPlaceholderText.color.r, idPlaceholderText.color.g, idPlaceholderText.color.b, 0f);
        passwordPlaceholderText.color = new Color(passwordPlaceholderText.color.r, passwordPlaceholderText.color.g, passwordPlaceholderText.color.b, 0f);
        loginButtonText.color = new Color(loginButtonText.color.r, loginButtonText.color.g, loginButtonText.color.b, 0f);
        registerButtonText.color = new Color(registerButtonText.color.r, registerButtonText.color.g, registerButtonText.color.b, 0f);
        

        loginPanelImage.DOFade(1.0f, startTime);
        idInputFieldImage.DOFade(1.0f, startTime);
        passwordInputFieldImage.DOFade(1.0f, startTime);
        loginButtonImage.DOFade(1.0f, startTime);
        registerButtonImage.DOFade(1.0f, startTime);
        
        idPlaceholderText.DOFade(1.0f, startTime);
        passwordPlaceholderText.DOFade(1.0f,startTime);
        loginButtonText.DOFade(1.0f, startTime);
        registerButtonText.DOFade(1.0f, startTime);
    }

    public void OnLogin()
    {
        loginPanelImage.DOFade(0f, endTime);
        idInputFieldImage.DOFade(0f, endTime);
        passwordInputFieldImage.DOFade(0f, endTime);
        loginButtonImage.DOFade(0f, endTime);
        registerButtonImage.DOFade(0f, endTime);
        
        idPlaceholderText.DOFade(0f, endTime);
        passwordPlaceholderText.DOFade(0f, endTime);
        loginButtonText.DOFade(0f,endTime);
        registerButtonText.DOFade(0f, endTime);
        transform.DOScale(0f, endTime).OnComplete(() => 
        {
            gameObject.SetActive(false);
        });;
        transform.DOMove(new Vector3(0, -2.5f, 0), endTime);
    }
}