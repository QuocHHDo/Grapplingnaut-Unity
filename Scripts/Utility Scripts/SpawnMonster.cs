using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    [SerializeField] GameObject Monster;
    [SerializeField] GameObject Portal;
    //[SerializeField] GameObject Player;
    [SerializeField] GameObject PlayerCapsule;
    [SerializeField] public float xCoord;
    [SerializeField] public float yCoord;
    [SerializeField] public float zCoord;
    public float dist;
    private float spaceApart = 0f; // Space between player and portal
    private bool SpawnOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        dist = PlayerPrefs.GetFloat("distance");
        //Debug.Log("NEW SCENE DISTANCE: " + dist);
        PlayerCapsule = GameObject.Find("PlayerCapsule");
    }

    // Update is called once per frame
    void Update()
    {
        spaceApart = Vector3.Distance(Portal.transform.position, PlayerCapsule.transform.position);
        //Debug.Log("Space Apart: " + spaceApart); 
        if (spaceApart >= dist && SpawnOnce == false)
        {
            SpawnOnce = true;
            // Debug.Log("SPWAN FUNCTION CALLED");
            Spawn();
        }
    }
    private void Spawn()
    {
        //Debug.Log("Spawn Monster");
        //Instantiate(Monster, Portal.transform.position, Quaternion.identity);
        Instantiate(Monster, new Vector3(xCoord, yCoord, zCoord), Quaternion.identity); // Default was 0, 20, 0
    }
}
