using UnityEngine;

public class AuthConnecter : MonoBehaviour
{
    [SerializeField] private AuthManager authManager;
    [SerializeField] private AuthStatusModel authStatusModel;
    [SerializeField] private LoggerModel loggerModel;

    private void Start()
    {
        authManager.onLogin += authStatusModel.OnLogin;
        authStatusModel.onSuccess += loggerModel.OnLogin;
        authManager.onRegister += authStatusModel.OnRegister;
    }

    private void OnDestroy()
    {
        authManager.onLogin -= authStatusModel.OnLogin;
        authStatusModel.onSuccess -= loggerModel.OnLogin;
        authManager.onRegister -= authStatusModel.OnRegister;
    }
}
