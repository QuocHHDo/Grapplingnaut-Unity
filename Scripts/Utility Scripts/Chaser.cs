using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;
public class Chaser : MonoBehaviour
{
    //public DeathController death; 
    public GameObject target;
    public float speed = 1f;
    public float fasterSpeed = 5f;
    public float dist = 200f;

    public AudioSource dragonSound;
    bool isPlayed = false; 
   // bool isPlayed = false;
   // public AudioSource deathSound;
    private void Start()
    {
        // death = gameObject.GetComponent<DeathController>();
        target = GameObject.Find("PlayerCapsule");
        //dist = Vector3.Distance(transform.position, target.position); 
    }
    private void FixedUpdate()
    {
        /* the sun should be fixed distance awa y fromm the player (100m)
         * once the sun is less than 100m away, the sun would slow down and move at a constant speed to kill the player
         */

        float dist = Vector3.Distance(transform.position, target.transform.position);

        /*if the distance is less than 100, move at a constant speed*/
        if (dist < 100)
        {
            //Debug.Log("Running lower speed");
            transform.LookAt(target.transform.position);
            transform.position += transform.forward * speed * Time.deltaTime;
            //Debug.Log("Lower speed");
        }

        else
        {
            /*keep fixed distance bw the chaser and the player*/
            //Debug.Log("Running faster speed");
            transform.LookAt(target.transform.position);
            transform.position += transform.forward * fasterSpeed * Time.deltaTime;
            //  Debug.Log("Faster speed");
        }
        PlayerPrefs.SetFloat("distance", dist);
        if(dist < 50 && isPlayed == false)
        {
            dragonSound.Play();
            isPlayed = true; 
        }
        //Debug.Log(dist); 
    }
     /*
        private void OnDisable()
        {
            PlayerPrefs.SetFloat("distance", dist);   
        }
    */
}
