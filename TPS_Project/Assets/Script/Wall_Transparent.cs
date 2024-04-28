using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Transparent : MonoBehaviour
{
    private MainCamera MainCamera;

    private float Timer;

    private bool Collision_Check = false;

    new Renderer renderer;
    // Start is called before the first frame update
    private void Awake()
    {
        MainCamera = GameObject.Find("Main Camera").GetComponent<MainCamera>();

        renderer = this.GetComponent<Renderer>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Collision_Check == true)
        {
            Timer += Time.deltaTime;

            if (Timer > 0.1f)
            {
                if (renderer != null)
                {
                    Material material = renderer.material;
                    Color color = material.color;
                    color.a = 1.0f; // 투명도 조절
                    material.color = color;
                    Collision_Check = false;
                }
            }

        }
    }
       public void Trans()
    {
        Debug.Log("투과");
        Timer = 0;
        Collision_Check = true;
    }
}
