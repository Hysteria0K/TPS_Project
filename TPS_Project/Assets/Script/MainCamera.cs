using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MainCamera : MonoBehaviour
{
    public GameObject Player;

    public GameObject Player_Center;

    public Vector3 Pl_Pos;

    public Vector3 Camera_Center;

    private float Radius = 2.685f;

    public float Angle_X = 2.81f;
    public float Angle_Y = 0.0f;
    private float Y_Maximum = 15.0f;
    private float Y_Minimum = -15.0f;

    private float float_angle;

    private float Camera_Correction = 161.0828f;
    private float Camera_Y_Set = 2.05f;

    public float rotation_X;
    public float rotation_Y;

    public float speed_X = 1.5f;
    public float speed_Y = 15f;

    public bool Zoom_In_Check = false;
    private int Zoom_In_Count = 0;

    private float Angle_X_Correction = 0.2966995f;

    private float AfterFire_Y = 0.0f;
    public float Stacked_AfterFire_Y = 0.0f;

    private float Origin_Radius = 2.685f;
    private float Origin_Camera_Correction = 161.0828f;
    private float Origin_Camera_Y_Set = 2.05f;

    private bool Cam_Control_Check = false;

    public LayerMask Cam_Collision;

    public RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        ResetCamera();

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
            ResetCamera();
        }

        if (Angle_Y < Y_Minimum)
        {
            Angle_Y += 0.2f;
        }

        else if (Angle_Y > Y_Maximum)
        {
            Angle_Y = Y_Maximum;
        }

        if (Angle_Y < -30.0f)
        {
            Angle_Y = -30.0f;
        }

        Recoil_Control();

        Camera_Collision(); 

    }
    void FixedUpdate()
    {
        Pl_Pos = Player.GetComponent<Player>().Player_Position;

        Pl_Pos.y = Pl_Pos.y + Camera_Y_Set;

        Camera_Center = Pl_Pos;

        rotation_X = Input.GetAxis("Mouse X") * speed_X;

        rotation_Y = Input.GetAxis("Mouse Y") * speed_Y;

        Angle_X += rotation_X * Time.deltaTime; // 앵글 = 파이값, 마우스 움직이는거에 넣으면 될듯

        if (Angle_Y < Y_Maximum || rotation_Y > 0)
        {
            Angle_Y -= rotation_Y * Time.deltaTime;
        }

        if (Angle_X < 0) Angle_X += 2*Mathf.PI;
        else if (Angle_X > 2*Mathf.PI) Angle_X -= 2*Mathf.PI;

        this.transform.position = Camera_Center + new Vector3(Mathf.Sin(Angle_X), 0, Mathf.Cos(Angle_X)) * Radius;

        float_angle = Angle_X * 180.0f/Mathf.PI;

        this.transform.rotation = Quaternion.Euler(new Vector3(Angle_Y, float_angle - Camera_Correction, 0) + Player.GetComponent<Gun>().Recoil);

        Zoom();

        Camera_Zoom_Correction();

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
        Radius -= 0.1185f;
        Camera_Y_Set -= 0.035f;
        Camera_Correction -= 1.7f;
        Angle_X -= Angle_X_Correction / 10;
    }

    private void Recoil_Control()
    {
        if (Player.GetComponent<Gun>().Recoil.x < 0.0f)
        {
            AfterFire_Y = Input.GetAxis("Mouse Y") * speed_Y * Time.deltaTime;

            if (AfterFire_Y > 0.0f)
            {
                AfterFire_Y = 0.0f;
            }

            Player.GetComponent<Gun>().Recoil.x -= AfterFire_Y;
            Stacked_AfterFire_Y += AfterFire_Y;
        }

        if (Player.GetComponent<Gun>().Recoil.x > 0.0f)
        {
            Player.GetComponent<Gun>().Recoil.x = 0.0f;
            AfterFire_Y = 0.0f;
            Stacked_AfterFire_Y = 0.0f;
        }
    }

    private void ResetCamera()
    {
        Player.GetComponent<Player>().Zoom_Check = false;

        Zoom_In_Check = false;
        Zoom_In_Count = 0;
        Radius = Origin_Radius;
        Camera_Correction = Origin_Camera_Correction;
        Camera_Y_Set = Origin_Camera_Y_Set;
        Angle_X += Angle_X_Correction;

        Player.GetComponent<Gun>().Recoil = Vector3.zero;
        AfterFire_Y = 0.0f;
        Player.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0.0f, this.transform.rotation.eulerAngles.y, 0.0f));
    }

    private void Camera_Zoom_Correction()
    {
        if (Angle_Y >= 5 && Player.GetComponent<Player>().Zoom_Check == true)
        {
            Camera_Y_Set = 1.7f + (Angle_Y - 5) * 0.025f;
            Radius = 1.5f - (Angle_Y - 5) * 0.08f;
            Camera_Correction = 144.0828f - (Angle_Y - 5) * 0.4f;

            if (Cam_Control_Check == false)
            {
                Cam_Control_Check = true;
            }
        }

        if (Angle_Y < 5 && Cam_Control_Check == true)
        {
            Camera_Y_Set = 1.7f;
            Radius = 1.5f;
            Camera_Correction = 144.0828f;
            Cam_Control_Check = false;
        }
    }

    private void Camera_Collision()
    {
        if (Physics.Raycast(transform.position, Player_Center.transform.position - transform.position, out hit, 3.0f, Cam_Collision))
        {
            // 교차한 mesh들을 모두 찾음
            RaycastHit[] hits = Physics.RaycastAll(transform.position, Player_Center.transform.position - transform.position, 3.0f, Cam_Collision);

            // 찾은 mesh들을 투명하게 만듦
            foreach (RaycastHit hitInfo in hits)
            {
                Renderer renderer = hitInfo.collider.GetComponent<Renderer>();
                Wall_Transparent wall = hitInfo.collider.GetComponent<Wall_Transparent>();
                if (renderer != null)
                {
                    Material material = renderer.material;
                    Color color = material.color;
                    color.a = 0.5f; // 투명도 조절
                    material.color = color;
                    wall.Trans();
                }
            }
        }
        //ChatGPT 참조함
    }

}
