using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainProjectileRandomizer : MonoBehaviour
{

    public GameObject projectile;
    public int projectileCount;
    private BoxCollider collider;
    public GameObject terrain;
    public int speed;
    public GameObject player;


    void Start()
    {
        collider = terrain.GetComponent<BoxCollider>();
        StartCoroutine(ExampleCoroutine());
    }

    void Update()
    {
   
    }


    public void SpawnProjectile()
    {

        Vector3 beginSpawnPoint = RandomStartingProjectileCoordinate();
        Vector3 endSpawnPoint = RandomEndingProjectileCoordinate();

        /* Send coordinates to the projectile */
        Instantiate(projectile, beginSpawnPoint, Quaternion.identity, transform);
        projectile.GetComponent<ProjectileMovement>().positions = endSpawnPoint;
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
    Vector3 RandomStartingProjectileCoordinate()
    {
        int x = 0;
        int y = 0;
        int z = 0;
        float spacing = 2f;

        x = (int)Random.Range(collider.bounds.min.x, collider.bounds.max.x);
        y = (int)Random.Range(collider.bounds.max.y / 2, collider.bounds.max.y);
        z = (int)collider.bounds.min.z; 

        Vector3 coord = new Vector3(x, y, z);

        return coord;
    }

    // Random spawn locations for projectiles
    Vector3 RandomEndingProjectileCoordinate()
    {
        int x = 0;
        int y = 0;
        int z = 0;
        float spacing = 2f;

        x = (int)Random.Range(collider.bounds.min.x, collider.bounds.max.x) - 100;
        y = (int)Random.Range(collider.bounds.max.y / 2, collider.bounds.max.y);
        z = (int)collider.bounds.max.z;

        Vector3 coord = new Vector3(x, y, z);

        return coord;
    }

}
