using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoggerModel : MonoBehaviour
{
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
        transform.DOMove(new Vector3(0, -0.5f, 0), 1f);
        transform.localScale = new Vector3(0,0,0);
        transform.DOScale(1f, 1f);
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
        

        loginPanelImage.DOFade(1.0f, 1f);
        idInputFieldImage.DOFade(1.0f, 1f);
        passwordInputFieldImage.DOFade(1.0f, 1f);
        loginButtonImage.DOFade(1.0f, 1f);
        registerButtonImage.DOFade(1.0f, 1f);
        
        idPlaceholderText.DOFade(1.0f, 1f);
        passwordPlaceholderText.DOFade(1.0f, 1f);
        loginButtonText.DOFade(1.0f, 1f);
        registerButtonText.DOFade(1.0f, 1f);
    }
}