using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class EnemyAnimation : EnemyScript
{
    Animator animator;

    bool hasSpeedParameter = false;
    bool hasAttackParameter = false;
    bool hasHurtParameter = false;
    bool hasDeadParameter = false;

    void Start()
    {
        animator = GetComponent<Animator>();

        hasSpeedParameter = HasParameter("speed");
        hasAttackParameter = HasParameter("attack");
        hasHurtParameter = HasParameter("hurt");
        hasDeadParameter = HasParameter("dead");

        core.health.enemyHit += OnHurt;
        core.health.enemyDeath += OnDeath;
        core.attack.attackStart += OnAttackStart;
    }

    private void FixedUpdate() {
        if (hasSpeedParameter)
            animator.SetFloat("speed", core.movement.navAgent.velocity.magnitude);  
        // Debug.Log(core.movement.navAgent.velocity.magnitude);
    }

    void OnAttackStart()
    {
        if (hasAttackParameter)
            animator.SetTrigger("attack");
    }

    void OnHurt( float _ )
    {
        if (hasHurtParameter)
            animator.SetTrigger("hurt");
    }

    void OnDeath()
    {
        if (hasDeadParameter)
            animator.SetBool("dead", true);
    }

    bool HasParameter(string name)
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.name == name)
            {
                return true;
            }
        }
        return false;
    }
}
