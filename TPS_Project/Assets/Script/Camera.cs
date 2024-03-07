using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Camera : MonoBehaviour
{
    public GameObject Player;

    public Vector3 Pl_Pos;

    public Vector3 Camera_Center;
    public float radius = 2.685f;
    public float speed = 2f;

    public float angle = 2.81f;
    public float acos2;
    // Start is called before the first frame update
    void Start()
    {
        /*Pl_Pos = Player.GetComponent<Player>().Player_Position;

        Pl_Pos.y = Pl_Pos.y + 2.05f;
        Pl_Pos.x = Pl_Pos.x + 0.87f;
        Pl_Pos.z = Pl_Pos.z - 2.54f;

        this.transform.position = Pl_Pos;*/
    }

    // Update is called once per frame
    void Update()
    {
        Pl_Pos = Player.GetComponent<Player>().Player_Position;

        Pl_Pos.y = Pl_Pos.y + 2.05f;

        Camera_Center = Pl_Pos;

        angle += speed * Time.deltaTime;

        this.transform.position = Camera_Center + new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle)) * radius;

        acos2 = Mathf.Acos(Mathf.Cos(angle))*180.0f/Mathf.PI;

        if (Mathf.FloorToInt(angle / Mathf.PI )% 2 == 1)
        {
            acos2 = -acos2;
            Debug.Log("¤·");
        }

        Quaternion rotation = Quaternion.Euler(new Vector3(0, acos2 - 161.0828f, 0));
        this.transform.rotation = rotation;
       

    }
}
