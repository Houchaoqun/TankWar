using UnityEngine;
using System.Collections;

public class BloodManager : MonoBehaviour {

    private Camera camera;
    string name;
    GameObject hero;
    float height;
    public Texture2D blood_red;
    public Texture2D blood_black;

    void Start()
    {
        // hero = GameObject.FindGameObjectWithTag("Player"); 
        name = gameObject.name;
        camera = Camera.main;
        float size_y = collider.bounds.size.y;
        //得到模型缩放比例 
        //float scal_y = transform.localScale.y;
        //它们的乘积就是高度 
        //   height = (size_y * scal_y);
        height = size_y;
    }


    void OnGUI()
    {

        Vector3 worldPosition = new Vector3(transform.position.x, height, transform.position.z);
        //根据 3D坐标换算成它在2D屏幕中的坐标 
        Vector2 position = camera.WorldToScreenPoint(worldPosition);
        //得到真实2D坐标

        position = new Vector2(position.x, Screen.height - position.y);

        //计算出血条的宽高 
        Vector2 bloodSize = GUI.skin.label.CalcSize(new GUIContent(blood_red));

        //通过血值计算红色血条显示区域

        int blood_width = blood_red.width * PlayerUI.PlayerLives / 10;
        //先绘制黑色血条    
        GUI.DrawTexture(new Rect(position.x - (bloodSize.x / 4), position.y - bloodSize.y, bloodSize.x / 2, bloodSize.y), blood_black);

        //在绘制红色血条

        GUI.DrawTexture(new Rect(position.x - (bloodSize.x / 4), position.y - bloodSize.y, blood_width / 2, bloodSize.y), blood_red);

        //计算名称的宽高 
        Vector2 nameSize = GUI.skin.label.CalcSize(new GUIContent(name));
        //设置显示颜色为黄色 
        GUI.color = Color.yellow;
        //绘制名称

        GUI.Label(new Rect(position.x - (nameSize.x / 2), position.y - nameSize.y - bloodSize.y, nameSize.x, nameSize.y), name);

    }
}
