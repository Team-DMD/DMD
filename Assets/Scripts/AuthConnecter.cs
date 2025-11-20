using UnityEngine;

public class AuthConnecter : MonoBehaviour
{
    [SerializeField] private AuthManager authManager;
    [SerializeField] private AuthStatusModel authStatusModel;

    private void Start()
    {
        authManager.onLogin += authStatusModel.OnLogin;
        authStatusModel.onConfirm+=authManager.Disable;
    }

    private void OnDestroy()
    {
        authManager.onLogin -= authStatusModel.OnLogin;
        authStatusModel.onConfirm -= authManager.Disable;
    }
}
