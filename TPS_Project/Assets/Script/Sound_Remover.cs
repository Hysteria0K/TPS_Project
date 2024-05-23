using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Remover : MonoBehaviour
{
    private AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (AudioSource.isPlaying == false)
        {
            Destroy(this.gameObject);
        }
    }
}
