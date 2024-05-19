using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Status : MonoBehaviour
{
    public GameObject Player;

    public GameObject Magazine_UI;
    public GameObject Full_Magazine_UI;
    public GameObject HealPack_Count_UI;

    public GameObject FullAuto;
    public GameObject BurstFire;
    public GameObject SemiAuto;
    public GameObject Pause;
    private bool Pause_Check;

    TextMeshProUGUI Magazine_UI_T;
    TextMeshProUGUI Full_Magazine_UI_T;
    TextMeshProUGUI HealPack_Count_UI_T;

    Gun gun;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        Magazine_UI_T = Magazine_UI.GetComponent<TextMeshProUGUI>();
        Full_Magazine_UI_T = Full_Magazine_UI.GetComponent<TextMeshProUGUI>();
        HealPack_Count_UI_T = HealPack_Count_UI.GetComponent<TextMeshProUGUI>();

        gun = Player.GetComponent<Gun>();

        player = Player.GetComponent<Player>();

        UI_Update();

        Pause.SetActive(false);

        Pause_Check = false;
    }

    // Update is called once per frame
    void Update()
    {
        Pause_ESC();
    }

    public void UI_Update()
    {
        switch (gun.Fire_Mode)
        {
            case 0:
                {
                    SemiAuto.SetActive(true);
                    BurstFire.SetActive(false);
                    FullAuto.SetActive(false);
                    break;
                }
            case 1:
                {
                    SemiAuto.SetActive(false);
                    BurstFire.SetActive(true);
                    FullAuto.SetActive(false);
                    break;
                }
            case 2:
                {
                    SemiAuto.SetActive(false);
                    BurstFire.SetActive(false);
                    FullAuto.SetActive(true);
                    break;
                }
        }

        Magazine_UI_T.text = string.Format("{0:D2}", gun.Magazine);

        Full_Magazine_UI_T.text = string.Format("{0:D2}", gun.Full_Magazine);

        HealPack_Count_UI_T.text = string.Format("{0:D2}", player.Heal_Pack);

    }

    private void Pause_ESC()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Pause.GetComponent<Pause_Button>().IsSetting == false && player.Die_Check == false)
        {
            if (Pause_Check == false)
            {
                Time.timeScale = 0.0f;
                Pause.SetActive(true);
                Pause_Check = true;
                Cursor.visible = true;
            }

            else if (Pause_Check == true)
            {
                Time.timeScale = 1.0f;
                Pause.SetActive(false);
                Pause_Check = false;
                Cursor.visible = false;
            }
        }
    }
}
