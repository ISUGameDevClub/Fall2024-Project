using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScript : MonoBehaviour
{
    private float hitLength = 0;
    public float damage = 3;
    // Start is called before the first frame update
    void Start()
    {
        damage = UpgradeScript.instance.meleeDamage.GetCurrentIntVal();
    }

    // Update is called once per frame
    void Update()
    {
        hitLength += Time.deltaTime;
        if (hitLength >= .1f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponentInParent<EnemyHealth>().TakeDamage(damage, AttackType.Melee);
        }
    }
    void OnUpgradeUpdate()
    {

    }
}
