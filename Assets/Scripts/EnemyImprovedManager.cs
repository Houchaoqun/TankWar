using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyImprovedManager : MonoBehaviour {

    public GameObject EnemyPerfabs;
    private int currentEnemyNumber = 5;
    private float EnemyTimer = 0;

    //设置显示游戏时间
    public Text GamgTimerShow;
    public static float GameTimer;

	// Use this for initialization

    void Awake()
    {
        ButtonManager.IsTimerGame = false;
        ButtonManager.IsNormalGame = false;
        ButtonManager.IsJianMieGame = true;
    }
    
	void Start () {
        GamgTimerShow.gameObject.SetActive(true);
        GameTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        GameTimer += Time.deltaTime;
        GamgTimerShow.text = "Game Time: " + GameTimer;

        if (PlayerUI.EnemyNumber < currentEnemyNumber)   //敌人数量总是满足5只,开始计时，20s后产生一只
        {
            EnemyTimer += Time.deltaTime;    
        }

        if(EnemyTimer >= 10)   //每隔10s随机增加一只敌机坦克  直到到达上限5只为止
        {
            float x = Random.Range(20, 180f);
            float z = Random.Range(20, 180f);
            GameObject.Instantiate(EnemyPerfabs, new Vector3(x, 2f, z), Quaternion.identity);
            PlayerUI.EnemyNumber++;

             EnemyTimer = 0;
        }

        //当在歼灭模式下，玩家消费完全部敌人，奖励分100000
        if (PlayerUI.EnemyNumber<=0)
        {
            PlayerUI.Score += 100000;
        }
	}
}
