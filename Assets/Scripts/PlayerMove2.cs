using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMove2 : MonoBehaviour {

    private float time;
    private float speed = 20f;
    public GameObject bullutPerfabs;
    public GameObject topGun;

    public Text getBloodAdd;
    private float getBloodAddTextTimer = 0;

    private Vector3 point;

    void Start()
    {
        getBloodAdd.gameObject.SetActive(false);
        point = transform.position;
    }


    void Update()
    {
        if (this.transform.position.x <= 0 || this.transform.position.x >= 200 || this.transform.position.z <= 0 || this.transform.position.z >= 200 )
        {
            //print("You lose!!! Player is died for itself!!");
            this.transform.position = new Vector3(100f,2f,100f);
            //Application.LoadLevel("GameOver");
            //Destroy(this.gameObject);
        }

        //if(JianMieButtonManager.IsPause != true)   //当游戏不处于暂停状态的时候，才可移动
        //{
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -2, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, 2, 0);
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
            }

            if (Input.GetKeyDown("space"))
            {
                //注意：在生成物体的时候，需要根据枪口的移动，生成的位置也要相应的移动一定的角度  transform.rotation
                GameObject.Instantiate(bullutPerfabs, topGun.transform.position, topGun.transform.rotation);
                //GameObject.Instantiate(shootBoom, transform.position, transform.rotation);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {

                    point = hit.point;

                    //关键：如何设置坦克前进方向，可通过调节坦克的父物体的collider的方向来解决
                    transform.LookAt(new Vector3(point.x, transform.position.y, point.z));

                    //if (Time.realtimeSinceStartup - time <= 0.2f)
                    //{
                    //    speed += 0.3f;
                    //}
                    //else
                    //{
                    //    speed = 0.15f;
                    //}

                    //time = Time.realtimeSinceStartup;
                }
            }

        //}



        //处理翻车的情况，矫正主角
        //if(Input.GetKey(KeyCode.Q))   
        //{
        //    print("you clicked Q!!");
        //    this.transform.Rotate(new Vector3(0f, transform.rotation.y, 0f));
        //}



        if (getBloodAddTextTimer > 0)
        {
            getBloodAddTextTimer -= Time.deltaTime;
        }

        if (getBloodAddTextTimer <= 0)
        {
            getBloodAdd.gameObject.SetActive(false);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "GetBlood")
        {
            getBloodAdd.gameObject.SetActive(true);
            getBloodAddTextTimer = 3f;  //获得血量的显示时间
        }
    }


}
