using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Camera : MonoBehaviour
{
    public GameObject Player;

    public Vector3 Pl_Pos;

    public Vector3 Camera_Center;

    public float radius = 2.685f;

    public float angle = 2.81f;
    public float acos;

    public float Camera_Correction = 161.0828f;
    public float Camera_Y_Set = 2.05f;

    public float rotation_X;
    public float speed_X = 1.5f;

    public bool Zoom_In_Check = false;
    public int Zoom_In_Count = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && Player.GetComponent<Player>().Zoom_Check == false)
        {
            Player.GetComponent<Player>().Zoom_Check = true;
        }
        else if (Input.GetMouseButtonDown(1) && Player.GetComponent<Player>().Zoom_Check == true)
        {
            Player.GetComponent<Player>().Zoom_Check = false;
        }
    }
    void FixedUpdate()
    {
        Pl_Pos = Player.GetComponent<Player>().Player_Position;

        Pl_Pos.y = Pl_Pos.y + Camera_Y_Set;

        Camera_Center = Pl_Pos;

        rotation_X = Input.GetAxis("Mouse X") * speed_X;

        angle += rotation_X * Time.deltaTime; // 앵글 = 파이값, 마우스 움직이는거에 넣으면 될듯

        if (angle < 0) angle += 2*Mathf.PI;
        else if (angle > 2*Mathf.PI) angle -= 2*Mathf.PI;

        this.transform.position = Camera_Center + new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle)) * radius;

        acos = Mathf.Acos(Mathf.Cos(angle))*180.0f/Mathf.PI;

        if (Mathf.FloorToInt(angle / Mathf.PI) % 2 == 1) acos = -acos;

        this.transform.rotation = Quaternion.Euler(new Vector3(0, acos - Camera_Correction, 0));

        Zoom();

    }

    private void Zoom()
    {
        if (Player.GetComponent<Player>().Zoom_Check == true)
        {
            if (Zoom_In_Check == false)
            {
                Player.GetComponent<Transform>().rotation = this.transform.rotation;
                StartCoroutine(Zoom_In());
            }
            if (Zoom_In_Count >= 10)
            {
                Zoom_In_Check = true;
                Player.GetComponent<Transform>().rotation = this.transform.rotation;
            }

        }

        else
        {
            Zoom_In_Check = false;
            Zoom_In_Count = 0;
            radius = 2.685f;
            Camera_Correction = 161.0828f;
            Camera_Y_Set = 2.05f;
        }
    }
        
    IEnumerator Zoom_In()
    {
        Zoom_In_Count++;

        yield return new WaitForSeconds(0.001f);
        radius -= 0.1185f;
        Camera_Y_Set -= 0.04f;
        Camera_Correction -= 1.7f;

    }
}
