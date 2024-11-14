using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimMelee : MonoBehaviour
{
    private Camera mainCam;
    public GameObject mHit;
    public float hitFreq = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        hitFreq = UpgradeScript.instance.meleeSpeed;
    }


    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);
        Vector3 mousePos = new Vector3(0,0,0);
        float hitDist;

        if (plane.Raycast(ray, out hitDist))
        {
            mousePos = ray.GetPoint(hitDist);
            transform.LookAt(mousePos);
        }

        Vector3 relPos = mousePos - this.transform.position;

        relPos.Normalize();

        Vector3 spawnPos = this.transform.position + relPos * 1.4f;

        hitFreq += Time.deltaTime;
        if (Input.GetMouseButtonDown(1) && hitFreq >= .7f)
        {
            GameObject swingBox = Instantiate(mHit, spawnPos, Quaternion.FromToRotation(transform.forward, spawnPos));
            swingBox.transform.SetParent(this.transform);
            hitFreq = 0;
        }
    }
    void OnUpgradeUpdate()
    {

    }

}
