using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

    public Image GameOverImage;
    private bool isLost;

    //显示游戏得分
    public Text ScoreOverText;

    //确定当前模式属于哪个模式
    public static bool IsNormalGame = false;    //普通模式
    public static bool IsJianMieGame = false;   //歼灭模式
    public static bool IsTimerGame = false;     //计时模式

    //历史成绩的存储
    public Text HighestScoreText;

    private float HighestScore ;   //参数分别表示名字和默认值0
    private float BestTime;

    void Awake()
    {
        HighestScore = PlayerPrefs.GetFloat("HistoryHighestScore", 0);   //参数分别表示名字和默认值0
        BestTime = PlayerPrefs.GetFloat("HistoryBestTime", 100000f);
    }

    void Start()
    {

        GameOverImage.gameObject.SetActive(false);
        ScoreOverText.gameObject.SetActive(false);
        HighestScoreText.gameObject.SetActive(false);

        isLost = PlayerUI.isPlayerDied;

        //不同的模式对应不同的显示（分数或者时间）
        if (IsNormalGame || IsTimerGame)   //普通模式和计时模式都是显示分数
        {
            ScoreOverText.text = "Score：" + PlayerUI.Score;

            if (HighestScore < PlayerUI.Score)
            {
                HighestScore = PlayerUI.Score;
                PlayerPrefs.SetFloat("HistoryHighestScore", HighestScore);
            }
            HighestScoreText.text = "HistoryHighestScore: " + HighestScore;

        }
        else if (IsJianMieGame)    //歼灭模式显示时间
        {

            if (PlayerUI.isPlayerDied)
            {
                ScoreOverText.text = "T^T...Try again!!";
            }
            else   //当消灭所有敌人的时候，才进行时间的对比和显示
            {
                if (BestTime > EnemyImprovedManager.GameTimer)
                {
                    BestTime = EnemyImprovedManager.GameTimer;
                    PlayerPrefs.SetFloat("HistoryBestTime", BestTime);
                }

                ScoreOverText.text = "Time Used：" + EnemyImprovedManager.GameTimer;                
            }
            HighestScoreText.text = "HistoryBestTime: " + BestTime;
        }



        //判断是输还是赢
        if (isLost)
        {
            GameOverImage.gameObject.SetActive(true);
            ScoreOverText.gameObject.SetActive(true);
            HighestScoreText.gameObject.SetActive(true);
        }
        else
        {
            GameOverImage.gameObject.SetActive(true);
            ScoreOverText.gameObject.SetActive(true);
            HighestScoreText.gameObject.SetActive(true);
        }
    }


    public void ReStart()
    {
        Application.LoadLevel("LevelChoose");
    }

    public void ReturnHome()
    {
        Application.LoadLevel("GameHome");
    }
}
