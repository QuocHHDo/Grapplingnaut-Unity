using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportScript : MonoBehaviour
{

    private int nextBuildIndex;
    private int currentBuildIndex;
    private bool allMapPlayedOnce; 
    // Start is called before the first frame update
    void Start()
    {
        currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        nextBuildIndex = currentBuildIndex; 
        System.Random rnd = new System.Random();
        
        //  while(currentBuild)
          while(currentBuildIndex == nextBuildIndex)
          {
              nextBuildIndex = rnd.Next(3, 9); // Map with lowest build # to Map with highest build #
          }
    }

    /*

    private void OnCollisionEnter(Collision collision)
    {

     
    }
    */

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("TeleportScript Triggering");
            //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(nextBuildIndex);        }
    }

}
