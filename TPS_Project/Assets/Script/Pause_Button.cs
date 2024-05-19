using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Button : MonoBehaviour
{
    public GameObject Pause_UI;
    public GameObject Setting_UI;

    public bool IsSetting;
    // Start is called before the first frame update
    void Start()
    {
        IsSetting = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Title_Button()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Title");
    }

    public void Setting_Button()
    {
        Pause_UI.SetActive(false);
        Setting_UI.SetActive(true);
        IsSetting = true;
    }
}
