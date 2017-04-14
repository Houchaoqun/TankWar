using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    public Text ScoreDis;
    public Text PlayerLivesDis;
    public Text EnemyNumberDis;

    //主角属性以及敌人数目
    public static float Score;
    public static int PlayerLives;
    public static int EnemyNumber;

    public static bool isPlayerDied;

    //tip信息,提示用户如何解决坦克翻转问题
    public Text tipText;
    private float tipTimer = 0;
    private bool isShowTip;


	// Use this for initialization
	void Start () {
        EnemyNumber = 5;
        Score = 0f;
        PlayerLives = 10;
        isPlayerDied = false;

        tipText.gameObject.SetActive(true);
        isShowTip = false;

	}
	
	// Update is called once per frame
	void Update () {
        tipTimer += Time.deltaTime;
        if(tipTimer>5)
        {
            tipText.gameObject.SetActive(false);
            isShowTip = false;
        }
        if(isShowTip)
        {
            tipText.gameObject.SetActive(true);
        }
        if(Input.GetKey(KeyCode.Q))
        {
            isShowTip = true;
            tipTimer = 0;
        }

        if (PlayerLives > 0)
        {
            ScoreDis.text = " " + Score;
            PlayerLivesDis.text = " " + PlayerLives;
            EnemyNumberDis.text = " " + EnemyNumber;
        }
        else
        {
            //print("you had died!!");
            isPlayerDied = true;
            Application.LoadLevel("GameLose");
            PlayerLives = 10;
        }

        if (EnemyNumber <= 0)
        {
            Application.LoadLevel("GameWin");
            //print("you won!!");
        }
           

	}
}
