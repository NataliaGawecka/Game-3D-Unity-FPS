using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
     private void OnTriggerEnter(Collider other)
    {
        print("hit" + other.name);
            Destroy(gameObject);
        
    }
}
