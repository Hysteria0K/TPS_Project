using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    public TMP_Text Text;

    private float Timer = 0.0f;
    private float Limit_Time = 1.0f;
    private float power = 2.0f;

    Color color;
    // Start is called before the first frame update
    void Start()
    {
        color = Text.color;
        color.a = 1.0f;
        Text.color = color;

        GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-180, 180), Random.Range(-90, 90), 0) * power, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        color.a -= 1 / Limit_Time * Time.deltaTime;

        if (Timer > Limit_Time)
        {
            Destroy(this.gameObject);
        }
        Text.color = color;
    }
}
