using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroidsmoving : MonoBehaviour
{
  float speed = 1f;
    float delta = 1f;  //delta is the difference between min y to max y.
 
    void Update() {
         float y = transform.position.y + Mathf.PingPong(speed * Time.time, delta); 
         Vector3 pos = new Vector3(transform.position.x, y, transform.position.z);
         transform.position = pos;
     }
}
