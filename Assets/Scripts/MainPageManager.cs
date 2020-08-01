using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPageManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField userName;
    [SerializeField]
    private GameObject userNameHint;
    [SerializeField]
    private TMP_InputField password;
    [SerializeField]
    private GameObject passwordHint;

    public void SelectChanger()
    {
        password.Select();
    }


    // To go next scene, when "sign in" button is clicked.
    // To send error message, when username and password are empty.
    public void PersonalPageScene()
    {
        TMP_InputField userNameInput= userName.GetComponent<TMP_InputField>();
        TMP_InputField passwordInput= password.GetComponent<TMP_InputField>();
        if(userNameInput.text !="" && passwordInput.text != "")
        {
            DataManager.UserName = userNameInput.text;
            SceneManager.LoadScene("PersonalInformation");
            return;
        }
        if(userNameInput.text=="")
        {
            TextMeshProUGUI TMPG = userNameHint.GetComponent<TextMeshProUGUI>();
            TMPG.color = Color.red;
            TMPG.text = "missing username";
        }
        if (passwordInput.text == "")
        {
            TextMeshProUGUI TMPG = passwordHint.GetComponent<TextMeshProUGUI>();
            TMPG.color = Color.red;
            TMPG.text = "missing password";
        }
    }
}
