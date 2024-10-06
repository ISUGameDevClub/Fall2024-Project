using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCore : MonoBehaviour
{
    [field: SerializeField]
    public Rigidbody rb {get; private set;}


    // this should be handeled differently once we have a Game Manager and such
    [field: SerializeField]
    public Transform player {get; private set;}


    [field: SerializeField]
    public EnemyPlayerDetector playerDetector {get; private set;}

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        // set all cores
        foreach (EnemyScript script in GetComponentsInChildren<EnemyScript>()) {
            script.SetCore(this);
        }
    }
}
