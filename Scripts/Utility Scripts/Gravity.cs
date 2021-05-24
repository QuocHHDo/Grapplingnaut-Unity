using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    [SerializeField] public float gravity; 

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, gravity, 0); //-30.0f
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
