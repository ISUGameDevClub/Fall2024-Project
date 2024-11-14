using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proto_EnemyProjectile : MonoBehaviour
{

    [SerializeField]
    private int damage;

    void OnCollisionEnter(Collision collision){
        collision.gameObject?.GetComponent<Health>().DamagePlayer(damage);
        Destroy(this.gameObject);
    }

    
}
