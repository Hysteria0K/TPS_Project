using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Com_Circle : MonoBehaviour
{
    public GameObject Pattern_Controller;

    public GameObject Table_Pattern;

    public Image Circle;

    private float Timer = 0.0f; //제한시간까지 차오름

    private float Limit = 60.0f; //제한시간

    private Com_Controller Com_Controller;

    private bool hit_check = false;

    void Awake()
    {
        Com_Controller = Pattern_Controller.GetComponent<Com_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= Limit)
        {
            Pattern_Failure();
        }
    }

    private void LateUpdate()
    {
        Circle_Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("컴터에 위치함");
            Com_Controller.Interaction_Enabled = true;
            hit_check = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("나갔음");
            Com_Controller.Interaction_Enabled = false;
            hit_check = false;
        }
    }
    public void Reset_Circle()
    {
        Timer = 0.0f;
    }

    private void Circle_Update()
    {
        Circle.fillAmount = (Limit - Timer) / Limit;
    }


    private void Pattern_Failure()
    {
        Com_Controller.Pattern_Miss += 1;
        Table_Pattern.SetActive(false);

        if (hit_check == true)
        {
            Com_Controller.Interaction_Enabled = false;
            hit_check = false;
        }

        this.gameObject.SetActive(false);
    }

}
