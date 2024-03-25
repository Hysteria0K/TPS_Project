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

    // Start is called before the first frame update
    void Start()
    {
        UI_Update();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UI_Update()
    {
        switch (Player.GetComponent<Gun>().Fire_Mode)
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

        Magazine_UI.GetComponent<TextMeshProUGUI>().text = string.Format("{0:D2}", Player.GetComponent<Gun>().Magazine);

        Full_Magazine_UI.GetComponent<TextMeshProUGUI>().text = string.Format("{0:D2}", Player.GetComponent<Gun>().Full_Magazine);

    }
}
