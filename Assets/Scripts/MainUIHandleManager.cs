using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

public class MainUIHandleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static string userName;
    public Text userInput;
    public InputField defaultInput;


    // Update is called once per frame
    public void Start()
    {
        Text text = userInput.GetComponent<Text>();
        if (StartManager.Instance.userName != null)
        {
            userName = StartManager.Instance.userName;
            defaultInput.text = userName;
        }
    }
    public void StartNewGame()
    {
        Text text = userInput.GetComponent<Text>();
            userName = text.text;
            StartManager.Instance.userName = userName;
        //Debug.Log("userName:" + userName);
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
