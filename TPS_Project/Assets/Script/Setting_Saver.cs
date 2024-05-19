using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting_Saver : MonoBehaviour
{
    public float Sound_Volume = 1.0f;
    public float Mouse_Speed = 1.0f;

    public float Min_Volume = 0.1f;
    public float Max_Volume = 2.0f;

    public float Min_Mouse = 0.1f;
    public float Max_Mouse = 2.0f;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
