using UnityEngine;
using System.Collections;

public class ParticleManager : MonoBehaviour {

    private float desTime = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        desTime += Time.deltaTime;
        if(desTime>5)
        {
            Destroy(this.gameObject);
        }
	}
}
