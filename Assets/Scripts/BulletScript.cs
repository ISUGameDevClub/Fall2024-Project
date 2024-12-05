using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float hitLength = 0;

    public int damage = 3;
    // Start is called before the first frame update
    void Start()
    {
        damage = UpgradeScript.instance.bulletDamage.GetCurrentIntVal();
    }

    // Update is called once per frame
    void Update()
    {
        hitLength += Time.deltaTime;
        if (hitLength >= 3f)
        {
            Destroy(this.gameObject);
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponentInParent<EnemyHealth>().TakeDamage(damage, AttackType.Melee);
        } else {
            Destroy(this.gameObject);
        }
    }
    void OnUpgradeUpdate()
    {

    }
}
