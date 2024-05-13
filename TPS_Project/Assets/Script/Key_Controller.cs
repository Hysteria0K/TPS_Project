using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class Key_Controller : MonoBehaviour
{
    public string Key_Data;

    public int State;

    public GameObject Key_Text;

    private Com_Controller Com_Pattern_Controller;

    public bool Key_Block = false;

    // Start is called before the first frame update

    private void Awake()
    {
        Com_Pattern_Controller = GameObject.Find("Com_Pattern_Controller").GetComponent<Com_Controller>();
    }
    void Start()
    {
        Key_Text.GetComponent<TextMeshProUGUI>().text = Key_Data;

        if (State != 0)
        {
            Key_Block = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Com_Pattern_Controller.Interaction_Mode == true && Com_Pattern_Controller.Key_Created == true && Com_Pattern_Controller.Pattern_State == State && Key_Block == false)
        {
            Press_Check();
        }
    }
    private void LateUpdate()
    {
        if (Key_Block == true && Input.anyKeyDown && Com_Pattern_Controller.Pattern_State == State && Com_Pattern_Controller.Interaction_Mode == true && Com_Pattern_Controller.Key_Created == true)
        {
            Key_Block = false;
        }
    }

    private void Press_Check()
    {
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                Debug.Log("Pressed key: " + keyCode);

                if (keyCode.ToString() == Key_Data)
                {
                    Debug.Log("Á¤´ä");
                    Com_Pattern_Controller.Pattern_State++;
                    Destroy(this.gameObject);
                }
                break;
            }
        }
    }
}
