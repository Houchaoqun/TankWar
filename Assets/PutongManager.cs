using UnityEngine;
using System.Collections;

public class PutongManager : MonoBehaviour {

	// Use this for initialization

    void Awake()
    {
        ButtonManager.IsJianMieGame = false;
        ButtonManager.IsTimerGame = false;
        ButtonManager.IsNormalGame = true;
    }

    public void ReStart()
    {
        //Time.timeScale = 1;
        //IsPause = false;
        Application.LoadLevel("Game");
    }

    public void Home()
    {
        Application.LoadLevel("GameHome");
        //IsPause = false;
    }
}
