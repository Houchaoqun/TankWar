using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    public static bool isPlayerBeBeat;
    public float timer;

    public Text ShowBeat;

	// Use this for initialization
	void Start () {
        isPlayerBeBeat = false;
        timer = 0f;

        ShowBeat.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlayerBeBeat)
        {
            ShowBeat.gameObject.SetActive(true);
            timer += Time.deltaTime;

            if (timer > 2f)
            {
                isPlayerBeBeat = false;
                ShowBeat.gameObject.SetActive(false);
                timer = 0;
            }
        }
        else
        { 

        }

	}

}
