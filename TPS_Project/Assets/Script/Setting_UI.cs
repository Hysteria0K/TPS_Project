using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting_UI : MonoBehaviour
{
    public GameObject Pause;

    public GameObject Pause_UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Escape_Settings();
    }

    private void Escape_Settings()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause.GetComponent<Pause_Button>().IsSetting = false;
            Pause_UI.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
