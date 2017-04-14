using UnityEngine;
using System.Collections;

public class AngleManager : MonoBehaviour {
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.localRotation.eulerAngles.x >= 30f)
        {
            print("dangerous");
            this.transform.Rotate(new Vector3(30f,transform.rotation.y,transform.rotation.z));
        }
        else if (this.transform.localRotation.eulerAngles.x <= -30f)
        {
            print("dangerous");
            this.transform.Rotate(new Vector3(-30f, transform.rotation.y, transform.rotation.z));
        }
        else if (this.transform.localRotation.eulerAngles.z >= 20f)
        {
            print("dangerous");
            this.transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, 30f));
        }else if (this.transform.localRotation.eulerAngles.z <= -20f)
        {
            print("dangerous");
            this.transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, -30f));
        }
	}
}
