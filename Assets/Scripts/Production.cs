using UnityEngine;
using System.Collections;

public class Production : MonoBehaviour {

    public GameObject enemyPerfabs;

    public GameObject BloodAddCubePerfbabs;
    private float BloodTimer;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < PlayerUI.EnemyNumber; i++)
        {
            float x = Random.Range(20,180f);
            float z = Random.Range(20, 180f);
            GameObject.Instantiate(enemyPerfabs,new Vector3(x,2f,z),Quaternion.identity);
        }

        BloodTimer = 0;
	}

    void Update ()
    {
        BloodTimer += Time.deltaTime;
        if(BloodTimer > 30)   //30秒随机生成一个补血包
        {
            float x = Random.Range(20, 180f);
            float z = Random.Range(20, 180f);
            GameObject.Instantiate(BloodAddCubePerfbabs, new Vector3(x, 1f, z), Quaternion.identity);

            BloodTimer = 0;
        }
    }

	
}
