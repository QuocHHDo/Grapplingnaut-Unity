using UnityEngine;
using System.Collections;

public class ballcontroller : MonoBehaviour {

    /* Universal script to get projectile moving to some position */

    PlayerMovement playerMovement;
    //public GameObject positions;
    public Vector3 positions;
    public GameObject character;
    public float speed;
    public GameObject explosionPrefab;

    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {

        /*
        if (transform.position == positions)
        {
            //Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        */
        transform.position = Vector3.MoveTowards(transform.position, positions, Time.deltaTime * speed);

    }

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Collisison" + collision.gameObject.name);
        GameObject player = character.transform.GetChild(0).gameObject;

        if (collision.gameObject.name == player.name)
        {
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            // playerMovement.Die();
        }
    }

}
