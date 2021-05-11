using UnityEngine;
using System.Collections;
public class Gun : MonoBehaviour
{
    public float damage =10f;
    public float range=100f;
    public Camera fpsCam;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 30;
    public float lifeTime = 3;
    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            /*  Debug.Log(hit.transform.name);
              Target target=hit.transform.GetComponent<Target>();
              if(target != null)
              {
                  target.TakeDemage(damage);
              }*/
            GameObject bullet = Instantiate(bulletPrefab);
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), bulletSpawn.parent.GetComponent<Collider>());
            bullet.transform.position = bulletSpawn.position;
            Vector3 rotation = bullet.transform.rotation.eulerAngles;
            bullet.transform.rotation = Quaternion.Euler(rotation.x,transform.eulerAngles.y,rotation.z);
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);
            StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
        }
    }

   
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);

    }

}
