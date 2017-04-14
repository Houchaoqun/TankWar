using UnityEngine;
using System.Collections;

public class JianMieButtonManager : MonoBehaviour {

    //public static bool IsPause;

	// Use this for initialization
	void Start () {
        //IsPause = false;
        ButtonManager.IsJianMieGame = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //public void Pause()
    //{
    //    Time.timeScale = 0;
    //    IsPause = true;
    //}

    public void ReStart()
    {
        //Time.timeScale = 1;
        //IsPause = false;
        Application.LoadLevel("Game_jianmie");
    }

    public void Home()
    {
        Application.LoadLevel("GameHome");
        //IsPause = false;
    }
}
