using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    public Image reload;

    // Start is called before the first frame update
    void Start()
    {
        reload.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (reload.fillAmount >= 1)
        {
            reload.fillAmount = 0;
        }
    }
}
