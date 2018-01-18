using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonScript : Button {

    // Use this for initialization
    public void loadScene()
    {
        SceneManager.LoadScene("PlayerSelect", LoadSceneMode.Single);
    }

}
