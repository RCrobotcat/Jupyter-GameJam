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

    public void Login()
    {
        if (userName.text == AnswerConfig.userName
            && q1.text == AnswerConfig.Answer_1
            && q2.text == AnswerConfig.Answer_2
            && q3.text == AnswerConfig.Answer_3)
        {
            Debug.Log("Login Success");
            // TODO
        }
        else
        {
            Debug.Log("Login Failed");
        }
    }
}
