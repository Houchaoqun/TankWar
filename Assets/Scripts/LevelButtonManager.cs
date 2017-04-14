using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelButtonManager : MonoBehaviour {

    public Image jianmieImage;
    public Image jishiImage;
    public Image putongImage;

	// Use this for initialization
	void Start () {
        jianmieImage.gameObject.SetActive(false);
        jishiImage.gameObject.SetActive(false);
        putongImage.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void jianmieButton()
    {
        jianmieImage.gameObject.SetActive(true);
        jishiImage.gameObject.SetActive(false);
        putongImage.gameObject.SetActive(false);
    }

    public void jishiButton()
    {
        jianmieImage.gameObject.SetActive(false);
        jishiImage.gameObject.SetActive(true);
        putongImage.gameObject.SetActive(false);
    }

    public void putongButton()
    {
        jianmieImage.gameObject.SetActive(false);
        jishiImage.gameObject.SetActive(false);
        putongImage.gameObject.SetActive(true);
    }

    public void ReturnHomeButton()
    {
        Application.LoadLevel("GameHome");
    }

    public void jianmieStart()
    {
        Application.LoadLevel("Game_jianmie");
    }



    public void putongStart()
    {
        //直接开始游戏
        Application.LoadLevel("Game");
    }

    public void jishiStart()
    {
        //先修改游戏参数，以及设置游戏时钟，再开始游戏
        Application.LoadLevel("Game_Timer");
    }

}
