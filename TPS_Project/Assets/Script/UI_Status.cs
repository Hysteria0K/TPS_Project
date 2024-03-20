using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Status : MonoBehaviour
{
    public GameObject Player;

    public GameObject Fire_Mode_UI;
    public GameObject Magazine_UI;
    public GameObject Full_Magazine_UI;

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
                    Fire_Mode_UI.GetComponent<Text>().text = "�ܹ�";
                    break;
                }
            case 1:
                {
                    Fire_Mode_UI.GetComponent<Text>().text = "����";
                    break;
                }
            case 2:
                {
                    Fire_Mode_UI.GetComponent<Text>().text = "����";
                    break;
                }
        }

        Magazine_UI.GetComponent<TextMeshProUGUI>().text = string.Format("{0:D2}", Player.GetComponent<Gun>().Magazine);

        Full_Magazine_UI.GetComponent<TextMeshProUGUI>().text = string.Format("{0:D2}", Player.GetComponent<Gun>().Full_Magazine);

    }
}
