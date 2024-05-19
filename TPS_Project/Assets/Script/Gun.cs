using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Player;
    public GameObject BulletPrefab;
    public GameObject BulletStart;
    public GameObject Camera;
    public GameObject UI_Status;
    public GameObject CartridgePrefab;
    public GameObject CartridgeOut;
    public GameObject Reload_Image;
    public GameObject Com_Controller;

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

    private float Reload_Timer = 0.0f;
    private float Reload_Timer_Limit = 2.0f;
    private float Reload_Timer_Tactical = 1.0f;
    private bool Reload_Check = false;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();

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
        if (Player.GetComponent<Player>().Die_Check == false)
        {
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

            if (Com_Controller.GetComponent<Com_Controller>().Interaction_Mode != true)
            {
                Reload();
                ChangeMode();
            }
        }
    }
    private void ChangeMode()
    {
        if (Input.GetKeyDown(KeyCode.V) && Burst_Check == false && Auto_Check == false && Time.timeScale != 0.0f)
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
            Reload_Check = true;
        }

        if (Reload_Check == true)
        {
            animator.SetBool("Reloading", true);
            Fire_Ready = false;
            Reload_Timer += Time.deltaTime;

            if (Magazine == 0)
            {
                Reload_Image.GetComponent<Reload>().reload.fillAmount += 1 / Reload_Timer_Limit * Time.deltaTime;
                if (Reload_Timer > Reload_Timer_Limit)
                {
                    Magazine = Full_Magazine - 1;
                    Reload_Check = false;
                    animator.SetBool("Reloading", false);
                    UI_Status.GetComponent<UI_Status>().UI_Update();
                    Fire_Ready = true;
                    Reload_Timer = 0.0f;
                }
            }
            else
            {
                Reload_Image.GetComponent<Reload>().reload.fillAmount += 1 / Reload_Timer_Tactical * Time.deltaTime;
                if (Reload_Timer > Reload_Timer_Tactical)
                {
                    Magazine = Full_Magazine;
                    Reload_Check = false;
                    animator.SetBool("Reloading", false);
                    UI_Status.GetComponent<UI_Status>().UI_Update();
                    Fire_Ready = true;
                    Reload_Timer = 0.0f;
                }
            }
        }
    }

    private void SemiAuto()
    {
        if (this.gameObject.GetComponent<Player>().Zoom_Check == true && Input.GetMouseButtonDown(0) && Magazine != 0 && Time.timeScale != 0.0f)
        {
            Fire();
        }
        else if (this.gameObject.GetComponent<Player>().Zoom_Check == true && Input.GetMouseButtonDown(0) && Magazine == 0 && Time.timeScale != 0.0f)
        {
            Reload_Check = true;
        }
    }

    private void BurstFire()
    {
        if (this.gameObject.GetComponent<Player>().Zoom_Check == true && Input.GetMouseButtonDown(0) && Magazine != 0 && Burst_Check == false && Time.timeScale != 0.0f)
        {
            Burst_Check = true;
            Timer += Burst_Time;
            Debug.Log("Burst!");
        }

        else if (this.gameObject.GetComponent<Player>().Zoom_Check == true && Input.GetMouseButtonDown(0) && Magazine == 0 && Burst_Check == false && Time.timeScale != 0.0f)
        {
            Reload_Check = true;
        }

        if (Burst_Check == true)
        {
            Timer += Time.deltaTime;

            if (Timer >= Burst_Time)
            {
                if (Magazine != 0 && Burst_Count < 3)
                {
                    Fire();
                    Burst_Count += 1;
                    Timer = 0.0f;
                }
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
        if (this.gameObject.GetComponent<Player>().Zoom_Check == true && Input.GetMouseButton(0) && Magazine != 0 && Auto_Check == false && Time.timeScale != 0.0f)
        {
            Fire();
            Auto_Check = true;
        }

        else if (this.gameObject.GetComponent<Player>().Zoom_Check == true && Input.GetMouseButton(0) && Magazine == 0 && Auto_Check == false && Time.timeScale != 0.0f)
        {
            Reload_Check = true;
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

        if (Fire_Timer >= 0.01f) //애니메이터
        {
            animator.SetBool("Shooting", false);
        }

        if (Fire_Timer >= Fire_Timer_Limit)
        {
            Fire_Check = false;
            Fire_Timer = 0.0f;
        }

        if (Fire_Check == false)
        {
            if (Max_Recoil_x == 0.0f || Max_Recoil_x > Recoil.x) Max_Recoil_x = Recoil.x;

            if (Recoil.x > Camera.GetComponent<MainCamera>().Stacked_AfterFire_Y)
            {
                Camera.GetComponent<MainCamera>().Angle_Y += Recoil.x;
                Recoil_Timer = 0.0f;
                Recoil.x = 0.0f;
            }

            else
            {
                Calculated_Recoil_X = Max_Recoil_x - Camera.GetComponent<MainCamera>().Stacked_AfterFire_Y;
            }
        }

        if (Calculated_Recoil_X < 0.0f && Recoil.x <= 0.0f && Fire_Check == false)
        {
            Recoil_Timer += Time.deltaTime;

            if (Recoil_Timer >= Recoil_Timer_Limit)
            {
                Camera.GetComponent<MainCamera>().Angle_Y = Camera.GetComponent<MainCamera>().Angle_Y - Calculated_Recoil_X / 100 + Max_Recoil_x / 100;
                Recoil.x -= Max_Recoil_x / 100;
                Recoil_Timer = 0.0f;
            }
        }

        if (Recoil.x >= 0.0f)
        {
            Recoil.x = 0.0f;
            Max_Recoil_x = 0.0f;
            Calculated_Recoil_X = 0.0f;
            Camera.GetComponent<MainCamera>().Stacked_AfterFire_Y = 0.0f;
        }
    }

    private void Fire()
    {
        BulletPrefab.GetComponent<Bullet>().Bullet_Type = Fire_Mode;
        Instantiate(BulletPrefab, BulletStart.transform.position, BulletStart.transform.rotation);
        Instantiate(CartridgePrefab, CartridgeOut.transform.position,
            Quaternion.Euler(new Vector3(CartridgeOut.transform.rotation.eulerAngles.x + 90.0f, this.transform.rotation.eulerAngles.y, CartridgeOut.transform.rotation.eulerAngles.z))); //탄피
        animator.SetBool("Shooting", true);
        Magazine -= 1;
        Increase_Recoil();
        Fire_Check = true;
        Fire_Timer = 0.0f;
        UI_Status.GetComponent<UI_Status>().UI_Update();
    }

}
