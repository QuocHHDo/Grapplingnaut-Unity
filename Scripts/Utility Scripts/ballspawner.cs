using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballspawner : MonoBehaviour
{
    [SerializeField] public GameObject ballTile;
    [SerializeField] public GameObject bird;
    public GameObject nextSpawnPoint;
    public GameObject spawnPoint;


    // Start is called before the first frame update
    void Start()
    {
          StartCoroutine(ExampleCoroutine());
    }


    IEnumerator ExampleCoroutine()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 pos_bird = nextSpawnPoint.transform.position;
            Instantiate(bird, pos_bird, Quaternion.identity);
            yield return new WaitForSecondsRealtime(1f);

            Vector3 pos = spawnPoint.transform.position;
            Instantiate(ballTile, pos, Quaternion.identity);
            yield return new WaitForSecondsRealtime(5f);
            //yield return new WaitForSecondsRealtime(1f); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
