using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Move : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Canvas;
    public GameObject Player;

    public float Rotate_X;
    public float Rotate_Y;

    public float Camera_Rotate_X;

    public int Position_Move;
    // Start is called before the first frame update
    void Start()
    {
        Rotate_Y = 10;
        Position_Move = 300;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Position_Move, -100.0f, 0) + Canvas.transform.position;

        Rotate();

        Zoom_Move();

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

    private void Zoom_Move()
    {
        if (Player.GetComponent<Player>().Zoom_Check == true && Position_Move > 30)
        {
            StartCoroutine(Zoom_In());
        }
        else if (Player.GetComponent<Player>().Zoom_Check != true && Position_Move < 270)
        {
            StartCoroutine(Zoom_Out());
        }

    }

    IEnumerator Zoom_In()
    {
        yield return new WaitForSeconds(0.001f);
        Position_Move -= 30;
    }
    IEnumerator Zoom_Out()
    {
        yield return new WaitForSeconds(0.001f);
        Position_Move += 30;
    }
}
