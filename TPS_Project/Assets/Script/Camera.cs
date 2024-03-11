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

    public float Angle_X = 2.81f;
    public float Angle_Y = 0.0f;
    public float Y_Maximum = 5.0f;
    public float Y_Minimum = -15.0f;

    public float float_angle;

    public float Camera_Correction = 161.0828f;
    public float Camera_Y_Set = 2.05f;

    public float rotation_X;
    public float rotation_Y;

    public float speed_X = 1.5f;
    public float speed_Y = 15f;

    public bool Zoom_In_Check = false;
    public int Zoom_In_Count = 0;


    public float Angle_X_Correction = 0.2966995f;

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

            Zoom_In_Check = false;
            Zoom_In_Count = 0;
            radius = 2.685f;
            Camera_Correction = 161.0828f;
            Camera_Y_Set = 2.05f;
            Angle_X += Angle_X_Correction;
           
        }
    }
    void FixedUpdate()
    {
        if (Angle_Y < Y_Minimum)
        {
            Angle_Y = Y_Minimum;
        }
        else if(Angle_Y > Y_Maximum)
        {
            Angle_Y = Y_Maximum;
        }

        Pl_Pos = Player.GetComponent<Player>().Player_Position;

        Pl_Pos.y = Pl_Pos.y + Camera_Y_Set;

        Camera_Center = Pl_Pos;

        rotation_X = Input.GetAxis("Mouse X") * speed_X;

        rotation_Y = Input.GetAxis("Mouse Y") * speed_Y;

        Angle_X += rotation_X * Time.deltaTime; // 앵글 = 파이값, 마우스 움직이는거에 넣으면 될듯

        Angle_Y += rotation_Y * Time.deltaTime;

        if (Angle_X < 0) Angle_X += 2*Mathf.PI;
        else if (Angle_X > 2*Mathf.PI) Angle_X -= 2*Mathf.PI;

        this.transform.position = Camera_Center + new Vector3(Mathf.Sin(Angle_X), 0, Mathf.Cos(Angle_X)) * radius;

        float_angle = Angle_X * 180.0f/Mathf.PI;

        this.transform.rotation = Quaternion.Euler(new Vector3(Angle_Y, float_angle - Camera_Correction, 0));

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
    }
        
    IEnumerator Zoom_In()
    {
        Zoom_In_Count++;

        yield return new WaitForSeconds(0.001f);
        radius -= 0.1185f;
        Camera_Y_Set -= 0.035f;
        Camera_Correction -= 1.7f;
        Angle_X -= Angle_X_Correction / 10;
    }
}
