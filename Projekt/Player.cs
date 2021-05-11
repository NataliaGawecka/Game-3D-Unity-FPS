using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float live = 5.0f;
    
    // Update is called once per frame
    void Update()
    {
        if (live == 0)
        {
            DestroyPlayer();
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("projectile"))
        {
            live -= 1.0f;
            Debug.Log("Player hit");
        }
    }

    void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}
