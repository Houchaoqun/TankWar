using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerbullutManager : MonoBehaviour
{
    public float bullutSpeed = 30f;
    public GameObject enemyDieParticle;
    public GameObject TreeTerrainPartilce;

    //public Text BullutNote;
    //private float NoteTime;

    void Start()
    {
        //BullutNote.gameObject.SetActive(false);
        //NoteTime = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        float f = bullutSpeed * Time.deltaTime;   //子弹飞行方向
        transform.Translate(Vector3.right * f);
        //X [0,200],Z [0,200]
        if (transform.position.x > 200 || transform.position.x < 0 || transform.position.z > 200 || transform.position.z<0)
        {
            Destroy(this.gameObject);          
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //print("beat an enemy!!");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            GameObject.Instantiate(enemyDieParticle,other.transform.position,other.transform.rotation);
            PlayerUI.EnemyNumber--;
            PlayerUI.Score += 100f;
        }

        else if(other.gameObject.tag == "Terrain" || other.gameObject.tag == "Trees")
        {
            Destroy(this.gameObject);
            GameObject.Instantiate(TreeTerrainPartilce, other.transform.position, other.transform.rotation);
            //BullutNote.gameObject.SetActive(true);
            //print("beat terrain or trees!");
        }
    }
}
