using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HomeButtonManager : MonoBehaviour {

    public Image IntroductionImage;
    public Image AboutAuthorImage;


	// Use this for initialization
	void Start () {
        IntroductionImage.gameObject.SetActive(false);
        AboutAuthorImage.gameObject.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void IntrodutionButton()
    {
        audio.Play();
        IntroductionImage.gameObject.SetActive(true);
        AboutAuthorImage.gameObject.SetActive(false);
    }

    public void AboutAuthorButton()
    {
        audio.Play();
        AboutAuthorImage.gameObject.SetActive(true);
        IntroductionImage.gameObject.SetActive(false);  
    }

    //public void SettingButton()
    //{
    //    audio.Play();
    //    IntroductionImage.gameObject.SetActive(false);
    //    AboutAuthorImage.gameObject.SetActive(false);

    //}

    public void StartButton()
    {
        audio.Play();
        Application.LoadLevel("LevelChoose");
    }

    public void QuitButton()
    {
        audio.Play();
        Application.Quit();
    }

    
}
