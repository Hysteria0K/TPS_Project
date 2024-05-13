using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Com_Controller : MonoBehaviour
{
    public GameObject Table_Clover;
    public GameObject Table_Spade;
    public GameObject Table_Heart;
    public GameObject Table_Diamond;

    public GameObject A_Circle;
    public GameObject B_Circle;
    public GameObject C_Circle;
    public GameObject D_Circle;

    public GameObject Interaction_UI;

    public GameObject Player;

    public GameObject Key_UI;

    public Transform Pattern_UI;

    private float Timer;  // 패턴이 발동되는 시간

    private float Pattern_Time = 61.0f; // 간격

    public int Pattern_Miss = 1;

    public bool Interaction_Enabled;
    public bool Interaction_Mode;

    public bool Key_Created;

    private int[] Key = new int[8];

    public int Pattern_State;

    // Start is called before the first frame update
    void Start()
    {
        Table_Clover.SetActive(false);
        Table_Spade.SetActive(false);
        Table_Heart.SetActive(false);
        Table_Diamond.SetActive(false);

        A_Circle.SetActive(false);
        B_Circle.SetActive(false);
        C_Circle.SetActive(false);
        D_Circle.SetActive(false);

        Timer = 60.0f;

        Pattern_Miss = 1;

        Interaction_Enabled = false;
        Interaction_Mode = false;
        Key_Created = false;

        Pattern_State = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > Pattern_Time)
        {
            Select_Pattern();
            Timer = 0.0f;
        }

        Interaction_UI_Update();
        Interaction_Pattern();
    }

    private void Select_Pattern()
    {
        switch(Random.Range(0, 4)) // 0 클 1 스 2 하 3 다
        {
            case 0:
                {
                    Table_Clover.SetActive(true);
                    A_Circle.SetActive(true);
                    A_Circle.GetComponent<Com_Circle>().Reset_Circle();
                    break;
                }
            case 1:
                {
                    Table_Spade.SetActive(true);
                    B_Circle.SetActive(true);
                    B_Circle.GetComponent<Com_Circle>().Reset_Circle();
                    break;
                }
            case 2:
                {
                    Table_Heart.SetActive(true);
                    C_Circle.SetActive(true);
                    C_Circle.GetComponent<Com_Circle>().Reset_Circle();
                    break;
                }
            case 3:
                {
                    Table_Diamond.SetActive(true);
                    D_Circle.SetActive(true);
                    D_Circle.GetComponent<Com_Circle>().Reset_Circle();
                    break;
                }

            default: break;
        }
    }
    private void Interaction_UI_Update()
    {
        if (Interaction_Enabled == true && Player.GetComponent<Player>().Zoom_Check == false)
        {
            Interaction_UI.SetActive(true);
        }
        else
        {
            Interaction_UI.SetActive(false);
        }
    }
    private void Interaction_Pattern()
    {
        if (Interaction_Mode == true && Key_Created == false)
        {
            Create_Key();
        }

        if (Interaction_Enabled == true && Input.GetKeyDown(KeyCode.E) && Player.GetComponent<Player>().Zoom_Check == false)
        {
            Player.GetComponent<Animator>().SetFloat("Speed", 0);
            Interaction_Enabled = false;
            Interaction_Mode = true;
        }
    }
    private void Create_Key()
    {
        for (int i = 0; i < 8; i++)
        {
            Key[i] = Random.Range(0, 8);

            switch(Key[i])
            {
                case 0:
                    {
                        Key_UI.GetComponent<Key_Controller>().Key_Data = "Q";
                        break;
                    }
                case 1:
                    {
                        Key_UI.GetComponent<Key_Controller>().Key_Data = "W";
                        break;
                    }
                case 2:
                    {
                        Key_UI.GetComponent<Key_Controller>().Key_Data = "E";
                        break;
                    }
                case 3:
                    {
                        Key_UI.GetComponent<Key_Controller>().Key_Data = "R";
                        break;
                    }
                case 4:
                    {
                        Key_UI.GetComponent<Key_Controller>().Key_Data = "A";
                        break;
                    }
                case 5:
                    {
                        Key_UI.GetComponent<Key_Controller>().Key_Data = "S";
                        break;
                    }
                case 6:
                    {
                        Key_UI.GetComponent<Key_Controller>().Key_Data = "D";
                        break;
                    }
                case 7:
                    {
                        Key_UI.GetComponent<Key_Controller>().Key_Data = "F";
                        break;
                    }
                default: break;
            }
            Key_UI.GetComponent<Key_Controller>().State = i;
            Instantiate(Key_UI, new Vector3(-520 + 200 * i, 300, 0) + Pattern_UI.position, Quaternion.Euler(0, 0, 0), Pattern_UI);
        }
        Key_Created = true;
        Pattern_State = 0;
    }
}
