using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {

    public Text TimerShow;
    public static float GameTimer;
    private float leftTime;

    public Text EnemyTipShow;
    private float EnemyTipShowTimer = 0;

    public GameObject EnemyPerfabs;

	// Use this for initialization
	void Start () {
        TimerShow.gameObject.SetActive(true);
        EnemyTipShow.gameObject.SetActive(false);
        GameTimer = 120f;
        leftTime = GameTimer;

        ButtonManager.IsNormalGame = false;
        ButtonManager.IsJianMieGame = false;
        ButtonManager.IsTimerGame = true;
	}
	
	// Update is called once per frame
	void Update () {
        leftTime -= Time.deltaTime;
        TimerShow.text = "Time Left: " + leftTime;

        if(leftTime<=0f)
        {
            leftTime = GameTimer - 10f;  //leftTime = 2min重置游戏剩余时间（即敌人翻倍数量）
            EnemyTipShow.gameObject.SetActive(true);         
            EnemyTipShow.text = "敌人已翻倍，当前敌人数量为:" + 2*PlayerUI.EnemyNumber;
            EnemyTipShowTimer = 0f;
            //翻倍敌机
            if (PlayerUI.EnemyNumber<15)
            {
                for (int i = 0; i < PlayerUI.EnemyNumber;i++ )
                {
                    float x = Random.Range(20, 180f);
                    float z = Random.Range(20, 180f);
                    GameObject.Instantiate(EnemyPerfabs, new Vector3(x, 2f, z), Quaternion.identity);
                }
            }
            PlayerUI.EnemyNumber = 2 * PlayerUI.EnemyNumber;

        }
        if (PlayerUI.EnemyNumber >= 15)   //当敌人数量达到15的时候，主角死亡，游戏结束
        {
            PlayerUI.PlayerLives = 0;
        }

        EnemyTipShowTimer += Time.deltaTime;
        if (EnemyTipShowTimer>5f)
        {
            EnemyTipShow.gameObject.SetActive(false);
        }
	}

    public void ReStart()
    {
        //Time.timeScale = 1;
        //IsPause = false;
        Application.LoadLevel("Game_Timer");
    }

    public void Home()
    {
        Application.LoadLevel("GameHome");
        //IsPause = false;
    }

}
