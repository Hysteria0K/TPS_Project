using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Servant_UI : MonoBehaviour
{
    private Transform Player_Pos;

    public Transform Servant;

    // Start is called before the first frame update
    private void Awake()
    {
        Player_Pos = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(Player_Pos);
    }
}
