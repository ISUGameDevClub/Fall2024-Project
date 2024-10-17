using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimMelee : MonoBehaviour
{
    private Camera mainCam;
    public GameObject mHit;
    private float hitFreq = 0;
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

        if (plane.Raycast(ray, out hitDist))
        {
            Vector3 mousePos = ray.GetPoint(hitDist);
            transform.LookAt(mousePos);
        }

        Vector3 relPos = mousePos - this.transform.position;

        relPos.Normalize();

        Vector3 spawnPos = this.transform.position + relPos * 2;

        hitFreq += Time.deltaTime;
        if (Input.GetMouseButtonDown(1) && hitFreq >= .5f)
        {
            Instantiate(mHit, spawnPos, Quaternion.FromToRotation(transform.forward, spawnPos));
            hitFreq = 0;
        }
    }

}
