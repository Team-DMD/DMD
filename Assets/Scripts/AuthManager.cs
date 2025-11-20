using System;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class AuthManager : MonoBehaviour,INetworkRequester
{
    [SerializeField] private TMP_InputField emailInput;
    [SerializeField] private TMP_InputField passwordInput;

    public Dictionary<int, Action> requests { get; set; } = new();

    public event Action<int> onLogin;
    public event Action<int> onRegister;

    private string _registerUrl = "http://52.78.203.32:8080/auth/signup";
    private string _loginUrl = "http://52.78.203.32:8080/auth/login";

    private void Start()
    {
        //requests.Add(200,);
    }
    
    public void OnRegisterClick()
    {
        StartCoroutine(Register(emailInput.text, passwordInput.text));
    }

    public void OnLoginClick()
    {
        StartCoroutine(Login(emailInput.text, passwordInput.text));
    }

    IEnumerator Register(string accountId, string password)
    {
        LoginData data = new LoginData { account_id = accountId, password = password };
        string jsonData = JsonUtility.ToJson(data);

        using (UnityWebRequest www = new UnityWebRequest(_registerUrl, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();
            onRegister?.Invoke((int)www.responseCode);
            Debug.Log(www.responseCode);
        }
    }

    IEnumerator Login(string email, string password)
    {
        LoginData data = new LoginData { account_id = email, password = password };
        string jsonData = JsonUtility.ToJson(data);

        using (UnityWebRequest www = new UnityWebRequest(_loginUrl, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();
            onLogin?.Invoke((int)www.responseCode);
            Debug.Log(www.responseCode);
        }
    }
    
    public void R200()
    {
        
    }

    public void UpLoadCode()
    {
        
    }

    public void AddAction(int code)
    {
        
    }

    public void RemoveCode(int code)
    {
        
    }

}
