using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake; 

public class KillPlayer : MonoBehaviour
{
    public AudioSource deathSound; 
    // Start is called before the first frame update
    bool isPlayed = false; 
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            if (!isPlayed)
            {
                deathSound.Play();
                CameraShaker.Instance.ShakeOnce(10f, 10f, 2.0f, 2f);
                Debug.Log("KillPlayer.cs: OnTriggerEnter AUDIO AND SHAKE");
                isPlayed = true;
            }
        }
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.SetActive(true);
            //StartCoroutine(waitForSound(col));
            StartCoroutine(waitForSound());
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            
            if(!isPlayed)
            {
                deathSound.Play();
                CameraShaker.Instance.ShakeOnce(10f, 10f, 2.0f, 2f);
                Debug.Log("KillPlayer.cs: OnCollisionEnter AUDIO AND SHAKE");
                isPlayed = true;
                // StartCoroutine(waitForSound(collision));
                StartCoroutine(waitForSound());
            }
        }
    }
    /*
    IEnumerator waitForSound(Collider col)
    {
        while(deathSound.isPlaying)
        {
            yield return null; 
        }
        col.gameObject.SetActive(false);
        Die();
    }
    */
    IEnumerator waitForSound()
    {
        while(deathSound.isPlaying)
        {
            yield return null;
        }
        Die(); 
    }
    public void Die()
    {
        SceneManager.LoadScene("EndMenu");
    }
}
