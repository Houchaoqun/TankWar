using UnityEngine;
using System.Collections;

public class enemyAI : MonoBehaviour {

    public const int STATE_STAND = 0;
    public const int STATE_WALK = 1;    
    public const int STATE_RUN = 2;   //敌人奔跑状态
    private int enemyState;          //记录当前敌人状态
    private GameObject hero;         //主角对象
    private float backUptime;       //备份上一次敌人思考时间
    public const int AI_THINK_TIME = 2;        //敌人思考后一次行为的时间
    public int AI_ATTACK_DISTANCE = 30;  //敌人的巡逻范围

    public GameObject enemy_bullet;
    public GameObject shot_point;



    int fire_delay = 0;

    void Start()
    {
        //得到主角对象
        hero = GameObject.Find("player");
        //设置默认敌人状态为站立状态
        enemyState = STATE_STAND;
    }


    void Update()
    {
        if(this.transform.position.x<=0||this.transform.position.x>=200||this.transform.position.z<=0||this.transform.position.z>=200)
        {
            //print("A enemy is droped for itself!!");
            //PlayerUI.EnemyNumber--;
            //PlayerUI.Score += 100;
            //Destroy(this.gameObject);
            float x = Random.Range(50f,150f);
            float z = Random.Range(50f, 150f);
            this.transform.position = new Vector3(x,5f,z);
        }

        //判断敌人与主角的距离
        if (Vector3.Distance(transform.position, hero.transform.position) < AI_ATTACK_DISTANCE)
        {
            enemyState = STATE_RUN;
            //设置敌人面朝主角方向
            transform.LookAt(hero.transform);
            fire_delay++;
            if (fire_delay % 20 == 0)
            {
                //生成炮弹
                Instantiate(enemy_bullet, shot_point.transform.position, shot_point.transform.rotation);
            }
            AI_ATTACK_DISTANCE = 50;  //第一次发现敌人后，将巡逻范围增大
        }
        //敌人进入巡逻状态
        else
        {
            //计算敌人思考时间
            fire_delay = 0;
            if (Time.time - backUptime >= AI_THINK_TIME)
            {
                //敌人开始思考
                backUptime = Time.time;
                Quaternion rotate = Quaternion.Euler(0, Random.Range(1, 5) * 90, 0);
                //1秒内完成敌人旋转
                transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * 1000);

                enemyState = STATE_WALK;

            }
        }

        switch (enemyState)
        {
            case STATE_STAND:
                break;
            case STATE_WALK:
                //敌人行走
                transform.Translate(Vector3.forward * Time.deltaTime);
                break;
            case STATE_RUN:
                //敌人朝向主角奔跑
                if (Vector3.Distance(transform.position, hero.transform.position) > 5f)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * 10);
                }
                else
                {
                    enemyState = STATE_WALK;
                }
                //else
                //{
                //    transform.Translate(Vector3.right * Time.deltaTime * 2);
                //}
                break;
        }
    }
}
