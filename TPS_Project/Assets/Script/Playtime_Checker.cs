using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playtime_Checker : MonoBehaviour
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
        Timer += Time.deltaTime;
    }
}
