using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject Camera;

    private int Full_Magazine = 61;
    public int Magazine = 0;

    public int Fire_Mode = 0; // 0 = semi-auto, 1 = burstfire, 2 = full-auto

    public int Burst_Count = 0;
    private bool Burst_Check = false;
    private float Timer;
    private float Burst_Time = 0.15f;

    public bool Fire_Ready = true;

    // Start is called before the first frame update
    void Start()
    {
        Timer = 0.0f;
        Magazine = Full_Magazine;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMode();

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
            }
        }

        Reload();
    }
    private void ChangeMode()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (Fire_Mode != 2) Fire_Mode += 1;
            else Fire_Mode = 0;
        }
    }


    private void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && Magazine != Full_Magazine)
        {
            if (Magazine == 0) Magazine = Full_Magazine - 1;
            else Magazine = Full_Magazine;
            //재장전 시간 격차 삽입 필요
        }
    }

    private void SemiAuto()
    {
        if (this.gameObject.GetComponent<Player>().Zoom_Check == true && Input.GetMouseButtonDown(0) && Magazine != 0)
        {
            Instantiate(BulletPrefab, Camera.transform.position, Camera.transform.rotation);
            Magazine -= 1;
            Debug.Log(Magazine);
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
                    Magazine -= 1;
                    Debug.Log(Magazine);
                    Burst_Count += 1;
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
}
