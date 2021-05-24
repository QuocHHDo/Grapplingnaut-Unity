using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Audio_Script : MonoBehaviour
{
    public AudioSource dragonSound;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(dragonAudioDelay()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator dragonAudioDelay()
    {
        yield return new WaitForSeconds(5);
        dragonSound.Play(); 
    }
}
