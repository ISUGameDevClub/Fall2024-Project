using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Camera mainCam;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canfire;
    private float timer;
    public float timeBetweenFire = 0.5f;
    public int bulletCount = 6;
    int bulletMax = 6;
    public float reloading;
    public float reloadTimer = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }


    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);
        float hitDist;
        
        if(plane.Raycast(ray, out hitDist))
        {
            Vector3 mousePos = ray.GetPoint(hitDist);
            transform.LookAt(mousePos);
            
        }
        if (bulletCount < bulletMax)
        {
            reloading += Time.deltaTime;
            if (reloading >= reloadTimer)
            {
                bulletCount++;
                reloading = 0;
            }
        }
        if (!canfire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFire)
            {
                canfire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButtonDown(0) && canfire && bulletCount > 0)
        {
            canfire = false;
            Shoot();
            bulletCount -= 1;
        }

        void Shoot()
        {
            GameObject newBullet = Instantiate(bullet, bulletTransform.position, bulletTransform.rotation);
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                
                rb.velocity = bulletTransform.forward * 60f; 
            }
        }
    }

}