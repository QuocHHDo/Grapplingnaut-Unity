using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autogeneration : MonoBehaviour
{
    [SerializeField] GameObject Grappable_Object;
    [SerializeField] GameObject Projectile_Object;
    [SerializeField] GameObject Points_Object;
    [SerializeField] GameObject map; 
    public GameObject Collider_Object;
    //public GameObject portal;

    public int Grappable_Object_Count; 
    public int Projectile_Object_Count;
    public int Points_Object_Count;

    private List<Vector3> prevPoints; 
    private BoxCollider collider; 
    private Vector3 colliderSize;
    private Bounds bounds;
    private Vector3 colliderMin;
    private Vector3 colliderMax;
    private MeshCollider meshCollider; 

    public Vector3 center; 
    // Start is called before the first frame update
    void Start()
    {
        meshCollider = map.AddComponent<MeshCollider>(); 
        prevPoints = new List<Vector3>();
        SpawnGrappableObject(Grappable_Object, Grappable_Object_Count);
        SpawnGrappableObject(Points_Object, Points_Object_Count); // Diamonds
    }

    public void SpawnGrappableObject(GameObject obj, int amount)
    {
        for (int i = 0; i < amount; ++i)
        {
            Vector3 randomPoint = RandomCoordinate();
            prevPoints.Add(randomPoint);

            Instantiate(obj, randomPoint, Quaternion.Euler(new Vector3(45f, 45f, 45f)));
            //GameObject tmp = GameObject.Instantiate(obj);
            //tmp.gameObject.transform.position = new Vector3(randomPoint.x, randomPoint.y, randomPoint.z);
        }
    } 
    Vector3 RandomCoordinate()
    {
        bounds = Collider_Object.GetComponent<BoxCollider>().bounds; 
        float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
        float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);
        float offsetZ = Random.Range(-bounds.extents.z, bounds.extents.z);

        Vector3 coord = center + new Vector3(offsetX, offsetY, offsetZ);
            
        
        if (prevPoints.Contains(coord)) return RandomCoordinate();
        
        if (meshCollider.bounds.Contains(coord))
        {
         //   Debug.Log("Asteroid touching map");
            RandomCoordinate(); 
        }

            return coord; 
    }
}
