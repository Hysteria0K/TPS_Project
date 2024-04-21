using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Transparent : MonoBehaviour
{
    private MainCamera MainCamera;
    // Start is called before the first frame update

    private void Awake()
    {
        MainCamera = GameObject.Find("MainCamera").GetComponent<MainCamera>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Trans()
    {
        
    }
}
