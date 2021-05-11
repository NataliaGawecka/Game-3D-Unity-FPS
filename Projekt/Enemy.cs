using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public float live = 5.0f;
    public float speed;
    public float stoppingDistance;
    public float retreadDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject Projectile;
   

    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
      
        timeBtwShots = startTimeBtwShots;
    }
    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            live -= 1.0f;
            Debug.Log("Enemy hit by bullet");
        }
    }

    void Update()
    {
        if (live == 0)
        {
            DestroyEnemy();
        }

        try
        {
            Player = GameObject.FindGameObjectWithTag("Player").transform;


            if (Vector3.Distance(transform.position, Player.position) > stoppingDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.position.x, transform.position.y, Player.position.z), speed * Time.deltaTime);

            }
            else if (Vector3.Distance(transform.position, Player.position) < stoppingDistance && Vector2.Distance(transform.position, Player.position) > retreadDistance)
            {
                transform.position = this.transform.position;

            }
            else if (Vector3.Distance(transform.position, Player.position) < retreadDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.position.x, transform.position.y, Player.position.z), -speed * Time.deltaTime);


            }

            if (timeBtwShots <= 0)
            {
                Instantiate(Projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
            transform.position.Set(transform.position.x, 0.0f, transform.position.z);

        }

        catch (MissingReferenceException)
        {
            Debug.Log("Player Dead");
        }
        catch (NullReferenceException)
        {

            Debug.Log("Player Dead");
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
