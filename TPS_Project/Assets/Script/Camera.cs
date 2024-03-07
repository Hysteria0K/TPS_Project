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
    public float speed = 1.5f;

    public float angle = 2.81f;
    public float acos;

    public float rotation_X;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Pl_Pos = Player.GetComponent<Player>().Player_Position;

        Pl_Pos.y = Pl_Pos.y + 2.05f;

        Camera_Center = Pl_Pos;

        rotation_X = Input.GetAxis("Mouse X") * speed;

        angle += rotation_X * Time.deltaTime; // 앵글 = 파이값, 마우스 움직이는거에 넣으면 될듯

        if (angle < 0) angle += 2*Mathf.PI;
        else if (angle > 2*Mathf.PI) angle -= 2*Mathf.PI;

        this.transform.position = Camera_Center + new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle)) * radius;

        acos = Mathf.Acos(Mathf.Cos(angle))*180.0f/Mathf.PI;

        if (Mathf.FloorToInt(angle / Mathf.PI) % 2 == 1) acos = -acos;

        this.transform.rotation = Quaternion.Euler(new Vector3(0, acos - 161.0828f, 0));

    }
}
