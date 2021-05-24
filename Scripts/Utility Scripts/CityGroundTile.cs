using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    /* Load asteroids and projectiles 
     * serializable: so that Unity can save and load those values */

    [SerializeField] public GameObject rockPrefab;
    [SerializeField] public int asteroidCount;
    [SerializeField] public GameObject terrain;
    [SerializeField] public GameObject portal;
    public float Score_To_Display_Portal;
    float score;
    int portalSpawned;
    private List<Vector3> prevPoints;
    private BoxCollider collider;


    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>(); // Find GroundSpawner Game Object
        prevPoints = new List<Vector3>(); // Init list to track previous pointss
        collider = terrain.GetComponent<BoxCollider>(); // Get this tiles collider

        SpawnObstacle(rockPrefab, asteroidCount);

        portalSpawned = PlayerPrefs.GetInt("portalSpawned", 0);

        if (portalSpawned == 1)
        {
            Debug.Log("Spawn Portal");
            GameObject tmp = Instantiate(portal);
            tmp.gameObject.transform.position = new Vector3(collider.bounds.min.x, collider.bounds.max.y / 2, collider.bounds.min.z / 3); // Spawn

            PlayerPrefs.SetInt("portalSpawned", 0);
        }
    }

    void Update()
    {
        score = PlayerPrefs.GetFloat("score", 0);

        if (score > Score_To_Display_Portal && score < (Score_To_Display_Portal + 0.01))
        {
            PlayerPrefs.SetInt("portalSpawned", 1);
            Debug.Log("PortalSpawned Set");
        }
    }


    /* Once player leaves tile, generate more */
    private void OnTriggerExit(Collider other)
    {
        if ( other.gameObject.tag == "Player")
        {
            groundSpawner.SpawnTile(true);
        }
      
    }


    private void OnTriggerEnter(Collider other)
    {

    }



    public void SpawnObstacle(GameObject obj, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject tmp = Instantiate(obj);
            Vector3 randomPoint = RandomCoordinate(); // Get random spawn coordinate
            prevPoints.Add(randomPoint); // Track coordinate to prevent overlap
            tmp.gameObject.transform.position = new Vector3(randomPoint.x, randomPoint.y, randomPoint.z); // Spawn

        }
    }



    // Random coordinates for asteroids
    Vector3 RandomCoordinate()
    {
        int x = 0;
        int y = 0;
        int z = 0;
        float spacing = 0.1f;

        x = (int)Random.Range(collider.bounds.min.x + 2, collider.bounds.max.x - 2);
        y = (int)Random.Range(collider.bounds.max.y / 2, collider.bounds.max.y);
        z = (int)Random.Range(collider.bounds.min.z + 2, collider.bounds.max.z - 2);

        /* Generate new coordinate with some padding */
        Vector3 coord = new Vector3(x + (x * 2 * spacing), y + (y * spacing), z + (z * 2 * spacing));

        /* Get new coordinate if it already exists */
        if (prevPoints.Contains(coord)) return RandomCoordinate();

        return coord;
    }

}
