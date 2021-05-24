using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using EZCameraShake;

public class DeathController : MonoBehaviour
{
    // Start is called before the first frame update
    bool isPlayed = false;
    bool alive = true;
    public AudioSource deathSound;
    void Start()
    {
       // Debug.Log("DeathController.cs");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other) // QUOC ADDED 
                                               // THIS CODE EXECUTED WHEN TOUCHING PLANE
    {
        
        if (other.CompareTag("Enemy")) // QUOC: MAY NOT WORK AS INTENDED
        {
            if (!isPlayed)
            {
                Debug.Log("!isPlayed");
                deathSound.Play();
                Debug.Log("Camera Shaker");
                CameraShaker.Instance.ShakeOnce(10f, 10f, 2.0f, 2f);
                Debug.Log("DeathController OnTriggerEnter other.CompareTag Audio and Shake");
                isPlayed = true;
            }
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("DeathController OnTriggerEnter other.gameObject.CompareTag(Enemy)");
                other.gameObject.SetActive(true);
                StartCoroutine(waitForSound());

            }
         }
        
    }
        
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        if(!isPlayed)
        {
            deathSound.Play();
            CameraShaker.Instance.ShakeOnce(10f, 10f, 2.0f, 2f);
            Debug.Log("DeathController OnCollisionEnter AUDIO AND SHAKE!");
            isPlayed = true;
            StartCoroutine(waitForSound());
        }
    }
    IEnumerator waitForSound() // QUOC ADDED: Deleted Collider other 
    {
        while (deathSound.isPlaying)
        {

            //Debug.Log("while loop"); 
            yield return null;
        }
        //other.gameObject.SetActive(false);
        Die();
    }
    public void Die() // QUOC ADDED 
    {
        Debug.Log("Die() function is called");
        alive = false;  // Restart the game 
        SceneManager.LoadScene("EndMenu");

    }
}
