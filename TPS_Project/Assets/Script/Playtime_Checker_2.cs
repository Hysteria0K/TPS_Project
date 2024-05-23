using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playtime_Checker_2 : MonoBehaviour
{
    public float Timer;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main_Stage_2")
        {
            Timer += Time.deltaTime;
        }
    }
}
