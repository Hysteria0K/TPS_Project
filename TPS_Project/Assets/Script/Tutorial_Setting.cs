using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Setting : MonoBehaviour
{
    public GameObject Setting_UI;
    public GameObject Title_UI;
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
            Setting_UI.SetActive(false);
            Title_UI.SetActive(true);
        }
    }
}
