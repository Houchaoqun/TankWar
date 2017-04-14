using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyBullutManager : MonoBehaviour {

    public float bullutSpeed = 30f;
    //private GameObject hero;
    //public GameObject PlayerParticle;


    void Start()
    {
        //hero = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        float f = bullutSpeed * Time.deltaTime;
        transform.Translate(Vector3.right * f);
        //X [0,200]
        //Z [0,200]
        if (transform.position.x > 200 || transform.position.x < 0 || transform.position.z > 200 || transform.position.z < 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
             
            PlayerUI.PlayerLives--;
            //print("beat player!!");

            TextManager.isPlayerBeBeat = true;
        }

        else if (other.gameObject.tag == "Terrain" || other.gameObject.tag == "Trees")
        {
            Destroy(this.gameObject);
            //print("beat terrain or trees!");
        }
    }
}
