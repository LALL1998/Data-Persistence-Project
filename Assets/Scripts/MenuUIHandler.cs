using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public Text BestScore;

    public void InputName(string s)
    {
        GameManager.instance.userName = s;
    }

    void Start()
    {
        GameManager.instance.Load();
        BestScore.text = $"BestScore: {GameManager.instance.highscore} : {GameManager.instance.highName}";
    }

    public void StartNew()
    {
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