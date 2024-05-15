using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Exit_Door : MonoBehaviour
{
    public Crystal_Controller CrystalController;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CrystalController.Crystal_Count == 0 && this.transform.position.y <= 8.64928f)
        {
            this.transform.position += transform.up * Time.deltaTime /20;
        }
    }
}
