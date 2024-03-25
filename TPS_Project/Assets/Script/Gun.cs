using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject Camera;
    public GameObject UI_Status;
    public GameObject CartridgePrefab;
    public GameObject CartridgeOut;

    public int Full_Magazine = 61;
    public int Magazine = 0;

    public int Fire_Mode = 0; // 0 = semi-auto, 1 = burstfire, 2 = full-auto

    private int Burst_Count = 0;
    private bool Burst_Check = false;
    private float Timer;
    private float Burst_Time = 0.15f;

    public bool Fire_Ready = true;

    private bool Auto_Check = false;

    public Vector3 Recoil = Vector3.zero;

    private float Vertical_Recoil = 0.5f;
    private float Horizontal_Recoil = 0.2f;
    public float Max_Recoil_x = 0.0f;
    public float Calculated_Recoil_X = 0.0f;

    public bool Fire_Check = false;
    private float Fire_Timer = 0.0f;
    private float Fire_Timer_Limit = 0.2f;

    private float Recoil_Timer = 0.0f;
    private float Recoil_Timer_Limit = 0.005f;

    // Start is called before the first frame update
    void Start()
    {
        Timer = 0.0f;
        Magazine = Full_Magazine;
        Recoil = Vector3.zero;
        Max_Recoil_x = 0.0f;

        Fire_Check = false;
        Fire_Timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMode();
        Decrease_Recoil();

        if (Fire_Ready)
        {
            switch (Fire_Mode)
            {
                case (0):
                    {
                        SemiAuto();
                        break;
                    }
                case (1):
                    {
                        BurstFire();
                        break;
                    }
                case (2):
                    {
                        FullAuto();
                        break;
                    }
            }
        }

        Reload();
    }
    private void ChangeMode()
    {
        if (Input.GetKeyDown(KeyCode.V) && Burst_Check == false && Auto_Check == false)
        {
            if (Fire_Mode != 2) Fire_Mode += 1;
            else Fire_Mode = 0;
            UI_Status.GetComponent<UI_Status>().UI_Update();
        }
    }


    private void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && Magazine != Full_Magazine)
        {
            if (Magazine == 0) Magazine = Full_Magazine - 1;
            else Magazine = Full_Magazine;
            //ÀçÀåÀü ½Ã°£ °ÝÂ÷ »ðÀÔ ÇÊ¿ä
            UI_Status.GetComponent<UI_Status>().UI_Update();
        }
    }

    private void SemiAuto()
    {
        if (this.gameObject.GetComponent<Player>().Zoom_Check == true && Input.GetMouseButtonDown(0) && Magazine != 0)
        {
            Instantiate(BulletPrefab, Camera.transform.position, Camera.transform.rotation);
            Instantiate(CartridgePrefab, CartridgeOut.transform.position,
                Quaternion.Euler(new Vector3(CartridgeOut.transform.rotation.eulerAngles.x + 90.0f, this.transform.rotation.eulerAngles.y, CartridgeOut.transform.rotation.eulerAngles.z))); //ÅºÇÇ
            Magazine -= 1;
            Debug.Log(Magazine);
            Increase_Recoil();
            Fire_Check = true;
            Fire_Timer = 0.0f;
            UI_Status.GetComponent<UI_Status>().UI_Update();
        }
    }

    private void BurstFire()
    {
        if (this.gameObject.GetComponent<Player>().Zoom_Check == true && Input.GetMouseButtonDown(0) && Magazine != 0 && Burst_Check == false)
        {
            Burst_Check = true;
            Timer += Burst_Time;
            Debug.Log("Burst!");
        }

        if (Burst_Check == true)
        {
            Timer += Time.deltaTime;

            if (Timer >= Burst_Time)
            {
                if (Magazine != 0 && Burst_Count < 3)
                {
                    Instantiate(BulletPrefab, Camera.transform.position, Camera.transform.rotation);
                    Instantiate(CartridgePrefab, CartridgeOut.transform.position,
                        Quaternion.Euler(new Vector3(CartridgeOut.transform.rotation.eulerAngles.x + 90.0f, this.transform.rotation.eulerAngles.y, CartridgeOut.transform.rotation.eulerAngles.z))); //ÅºÇÇ
                    Magazine -= 1;
                    Debug.Log(Magazine);
                    Burst_Count += 1;
                    Increase_Recoil();
                    Fire_Check = true;
                    Fire_Timer = 0.0f;
                    UI_Status.GetComponent<UI_Status>().UI_Update();
                }
                Timer = 0.0f;
            }

            if (Burst_Count >= 3 || Magazine == 0)
            {
                Burst_Count = 0;
                Burst_Check = false;
                Timer = 0.0f;
            }
        }
    }

    private void FullAuto()
    {
        if (this.gameObject.GetComponent<Player>().Zoom_Check == true && Input.GetMouseButton(0) && Magazine != 0 && Auto_Check == false)
        {
            Instantiate(BulletPrefab, Camera.transform.position, Camera.transform.rotation);
            Instantiate(CartridgePrefab, CartridgeOut.transform.position,
                Quaternion.Euler(new Vector3(CartridgeOut.transform.rotation.eulerAngles.x + 90.0f, this.transform.rotation.eulerAngles.y, CartridgeOut.transform.rotation.eulerAngles.z))); //ÅºÇÇ
            Magazine -= 1;
            Debug.Log(Magazine);
            Auto_Check = true;
            Increase_Recoil();
            Fire_Check = true;
            Fire_Timer = 0.0f;
            UI_Status.GetComponent<UI_Status>().UI_Update();
        }

        if (Auto_Check == true)
        {
            Timer += Time.deltaTime;

            if (Timer >= Burst_Time)
            {
                Timer = 0.0f;
                Auto_Check = false;
            }
        }
    }

    private void Increase_Recoil()
    {
        Recoil.x -= Vertical_Recoil;

        if( Random.Range(0, 2) == 0)
        {
            Recoil.y -= Horizontal_Recoil;
        }
        else
        {
            Recoil.y += Horizontal_Recoil;
        }
        
    }

    private void Decrease_Recoil()
    {
        if (Fire_Check == true)
        {
            Fire_Timer += Time.deltaTime;
        }

        if (Fire_Timer >= Fire_Timer_Limit)
        {
            Fire_Check = false;
            Fire_Timer = 0.0f;
        }

        if (Fire_Check == false)
        {
            if (Max_Recoil_x == 0.0f || Max_Recoil_x > Recoil.x) Max_Recoil_x = Recoil.x;

            if (Recoil.x > Camera.GetComponent<Camera>().Stacked_AfterFire_Y)
            {
                Camera.GetComponent<Camera>().Angle_Y += Recoil.x;
                Recoil_Timer = 0.0f;
                Recoil.x = 0.0f;
            }

            else
            {
                Calculated_Recoil_X = Max_Recoil_x - Camera.GetComponent<Camera>().Stacked_AfterFire_Y;
            }
        }

        if (Calculated_Recoil_X < 0.0f && Recoil.x <= 0.0f && Fire_Check == false)
        {
            Recoil_Timer += Time.deltaTime;

            if (Recoil_Timer >= Recoil_Timer_Limit)
            {
                Camera.GetComponent<Camera>().Angle_Y = Camera.GetComponent<Camera>().Angle_Y - Calculated_Recoil_X / 100 + Max_Recoil_x / 100;
                Recoil.x -= Max_Recoil_x / 100;
                Recoil_Timer = 0.0f;
            }
        }

        if (Recoil.x >= 0.0f)
        {
            Recoil.x = 0.0f;
            Max_Recoil_x = 0.0f;
            Calculated_Recoil_X = 0.0f;
            Camera.GetComponent<Camera>().Stacked_AfterFire_Y = 0.0f;
        }
    }
}
