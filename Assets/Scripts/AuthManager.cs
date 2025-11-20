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

    public event Action<bool> onLogin;
    public event Action<bool> onRegister;

    private string _registerUrl = "http://52.78.203.32:8080/auth/signup";
    private string _loginUrl = "http://52.78.203.32:8080/auth/login";

    private void Start()
    {
        
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

            if (www.result != UnityWebRequest.Result.Success)
            {
                //statusText.text = "Register Failed: " + www.error;
                onLogin?.Invoke(false);
            }
            else
            {
                //statusText.text = www.result.ToString();
                onLogin?.Invoke(true);
            }
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

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Login failed: {www.error}");
                onLogin?.Invoke(false);
            }
            else
            {
                string json = www.downloadHandler.text;
                //Debug.Log("Server Response: " + json);

                TokenResponse tokens = JsonUtility.FromJson<TokenResponse>(json);
                if (tokens != null && !string.IsNullOrEmpty(tokens.access_token))
                {
                    //statusText.text="Login Success";
                    onLogin?.Invoke(true);
                }
                else
                {
                    //statusText.text = "Login Failed";
                    onLogin?.Invoke(false);
                }
            }
        }
    }

    public void Disable()
    {
        gameObject.SetActive(false);
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
