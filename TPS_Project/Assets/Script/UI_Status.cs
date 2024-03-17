using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Status : MonoBehaviour
{
    public GameObject Player;

    public GameObject Fire_Mode_UI;
    public GameObject Magazine_UI;

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
                    Fire_Mode_UI.GetComponent<Text>().text = "단발";
                    break;
                }
            case 1:
                {
                    Fire_Mode_UI.GetComponent<Text>().text = "점사";
                    break;
                }
            case 2:
                {
                    Fire_Mode_UI.GetComponent<Text>().text = "연사";
                    break;
                }
        }

        Magazine_UI.GetComponent<Text>().text = Player.GetComponent<Gun>().Magazine.ToString();

    }
}
