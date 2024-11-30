using UnityEngine;
using UnityEngine.UI;

public class LoginInterface : MonoBehaviour
{
    public Button loginButton;
    public Text userName;
    public InputField q1;
    public InputField q2;
    public InputField q3;

    void Awake()
    {
        loginButton.onClick.AddListener(Login);
    }

    void Start()
    {
        userName.text = GameManager.Instance.currentUserName;
    }

    public void Login()
    {
        if (userName.text.ToLower() == AnswerConfig.userName.ToLower()
            && q1.text.ToLower() == AnswerConfig.Answer_1.ToLower()
            && q2.text.ToLower() == AnswerConfig.Answer_2.ToLower()
            && q3.text.ToLower() == AnswerConfig.Answer_3.ToLower())
        {
            Debug.Log("Login Success");
            GameManager.Instance.loginSuccess = true;
            SceneController.Instance.TransitionToSceneHandler("EXIT");
        }
        else
        {
            Debug.Log("Login Failed");
        }
    }
}
