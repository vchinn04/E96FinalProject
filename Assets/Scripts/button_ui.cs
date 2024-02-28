using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class button_ui : MonoBehaviour
{
    public void changeScene(int indexScene) {
        SceneManager.LoadScene(indexScene);
    }
}
