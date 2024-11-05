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
        if (core.movement.navAgent == null)
            return;
        if (hasSpeedParameter)
            animator.SetFloat("speed", core.movement.navAgent.velocity.magnitude);  
        // Debug.Log(core.movement.navAgent.velocity.magnitude);

        if (core.movement.state == EnemyMovementState.Persuit)
            if (core.rb.transform.position.x > core.player.transform.position.x)
                transform.localScale = new Vector3(-1, 1, 1);
            if (core.rb.transform.position.x < core.player.transform.position.x)
                transform.localScale = new Vector3(1, 1, 1);
        else
            if (core.movement.navAgent.velocity.x > 0.1f)
                transform.localScale = new Vector3(1, 1, 1);
            else if (core.movement.navAgent.velocity.x  < -0.1f)
                transform.localScale = new Vector3(-1, 1, 1);


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
