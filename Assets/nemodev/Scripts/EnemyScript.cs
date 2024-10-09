using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    protected EnemyCore core;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    public void SetCore(EnemyCore newCore) {
        if (core != null) {
            Debug.LogError("CORE ALREADY SET! ABORTING",this);
        }
        else {
            core = newCore;
        }
    }
}
