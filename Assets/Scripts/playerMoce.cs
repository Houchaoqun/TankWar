using UnityEngine;
using System.Collections;

public class playerMoce : MonoBehaviour {

    private Vector3 point;
    private float time;
    private float speed = 0;
    
    void Start()
    {
        point = transform.position;
        //playerLive = 3;
        //playerScore = 0;

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1, 0);
        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0);
        }

        // 注意与此的差别：Input.GetKey(KeyCode.Space)     
        //if (Input.GetKeyDown("space"))
        //{
        //    //注意：在生成物体的时候，需要根据枪口的移动，生成的位置也要相应的移动一定的角度  transform.rotation
        //    GameObject.Instantiate(bullutPerfabs, TopGun.transform.position, TopGun.transform.rotation);
        //}


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                point = hit.point;

                //关键：如何设置坦克前进方向，可通过调节坦克的父物体的collider的方向来解决
                transform.LookAt(new Vector3(point.x, transform.position.y, point.z));

                if (Time.realtimeSinceStartup - time <= 0.2f)
                {
                    speed += 0.3f;
                }
                else
                {
                    speed = 0.15f;
                }

                time = Time.realtimeSinceStartup;
            }
        }
    }


    void FixedUpdate()
    {
        if (Mathf.Abs(Vector3.Distance(point, transform.position)) >= 2.3f)  //点击下位置与坦克位置的距离大于2.3f的时候产生位移
        {
            transform.Translate(Vector3.forward * speed);
        }
    }  
}
