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

    public GameObject FullAuto;
    public GameObject BurstFire;
    public GameObject SemiAuto;

    TextMeshProUGUI Magazine_UI_T;
    TextMeshProUGUI Full_Magazine_UI_T;

    Gun gun;

    // Start is called before the first frame update
    void Start()
    {
        Magazine_UI_T = Magazine_UI.GetComponent<TextMeshProUGUI>();
        Full_Magazine_UI_T = Full_Magazine_UI.GetComponent<TextMeshProUGUI>();

        gun = Player.GetComponent<Gun>();


        UI_Update();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    }
}
