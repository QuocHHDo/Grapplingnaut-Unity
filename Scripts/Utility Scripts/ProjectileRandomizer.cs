using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRandomizer : MonoBehaviour
{

    /* This script randomly spawns projectiles and makes them go towards
     * the player */
  
    public GameObject projectile;
    public int projectileCount;
    private BoxCollider collider;
    public GameObject terrain;
    public int speed;
    public GameObject player;
    Vector3 playerPos;

    void Start()
    {
        collider = terrain.GetComponent<BoxCollider>(); 
        StartCoroutine(ExampleCoroutine());
        //SpawnProjectile();
    }

    void Update()
    {
         playerPos = player.transform.position;
    }


    public void SpawnProjectile()
    {

        Vector3 beginSpawnPoint = RandomProjectileCoordinate();
        

        // Choose another end point for projectile
        // Vector3 endSpawnPoint = new Vector3(collider.bounds.min.x, 50, 5);

        /* Send coordinates to the projectile */
        Instantiate(projectile, beginSpawnPoint, Quaternion.identity, transform);
        projectile.GetComponent<ProjectileMovement>().positions = playerPos; 
        projectile.GetComponent<ProjectileMovement>().speed = speed;

    }


    IEnumerator ExampleCoroutine()
    {
        for (int i = 0; i < projectileCount; i++)
        {
            SpawnProjectile();
            yield return new WaitForSecondsRealtime(1.5f);
        }
    }


    // Random spawn locations for projectiles
    Vector3 RandomProjectileCoordinate()
    {
        int x = (int)collider.bounds.max.x-100;
        int y = 0;
        int z = 0;
        float spacing = 2f;

        y = (int)Random.Range(collider.bounds.max.y/3, collider.bounds.max.y/2);
        z = (int)Random.Range(collider.bounds.min.z + 2, collider.bounds.max.z - 2);

        /* Generate new coordinate with some padding */
        Vector3 coord = new Vector3(x, y, z + (z * spacing));

        /* Get new coordinate if it already exists */
        //  if (prevPoints.Contains(coord)) return RandomCoordinate();

        return coord;
    }

 

}
