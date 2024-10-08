using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetector : EnemyScript
{
    public Action playerDetected;

    public Action playerLost;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            playerDetected?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            playerLost?.Invoke();
        }
    }
}
