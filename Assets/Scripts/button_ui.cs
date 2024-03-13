using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class button_ui : MonoBehaviour
{
    MajorManager major_manager;

    public void changeScene(int indexScene) {
        major_manager.ClearMajors();
        SceneManager.LoadScene(indexScene);
    }

    public void appQuit()
    {
        Application.Quit();
    }

    void Start()
    {
        major_manager = GameObject.Find("MajorManager").GetComponent<MajorManager>();

    }


}
