using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Move : MonoBehaviour
{
    public GameObject Camera;

    public float Rotate_X;
    public float Rotate_Y;

    public float Camera_Rotate_X;
    // Start is called before the first frame update
    void Start()
    {
        Rotate_Y = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (Camera.GetComponent<Transform>().rotation.x > 0)
        {
            Camera_Rotate_X = Camera.GetComponent<Transform>().rotation.eulerAngles.x;
        }
        else
        {
            Camera_Rotate_X = Camera.GetComponent<Transform>().rotation.eulerAngles.x - 360;
        }


        Rotate_X = Camera_Rotate_X + 15;

        if (Rotate_X < 0) Rotate_Y = -10;
        else Rotate_Y = 10;

        this.transform.rotation = Quaternion.Euler(Rotate_X, Rotate_Y, 0);
    }
}
