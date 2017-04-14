using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BloodAdd : MonoBehaviour {

    private float desTimer;

	// Use this for initialization
	void Start () {
        this.transform.Rotate(new Vector3(45f, 45f, 45f));
        desTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(Vector3.up * Time.deltaTime * 90);

        desTimer += Time.deltaTime;
        if(desTimer >= 30)
        {
            Destroy(this.gameObject);
            desTimer = 0;
        }

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (PlayerUI.PlayerLives < 10)
            {                
                PlayerUI.PlayerLives++;
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
            
        }
    }
}
