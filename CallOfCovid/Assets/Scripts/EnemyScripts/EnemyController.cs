﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;

    GameManager gameManager;

    Transform particleJoint;
  
    public Color gfx;

    // Animation
    public Animator anim;
    void Start()
    {
        
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        particleJoint = this.transform.Find("ParticleJoint");

        anim = this.GetComponent<Animator>();

    }

    public float attackRadius = 5f;

    private DateTime lastAttack = DateTime.Now;

    void Update()
    {
 
        float distance = Vector3.Distance(target.position, transform.position);

       
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);


            if (distance <= agent.stoppingDistance)
            {
               
                FaceTarget();
                Debug.Log("Distance is 5 or smaller!");
                
             

                if (gameManager.playerHealth.health > 0 && distance <= attackRadius)
                {
                    attack();
                }
         
                
            }


        }
        // For the particle system
        sneezeEffect.transform.position = particleJoint.position;
        sneezeEffect.transform.rotation = particleJoint.rotation;

        // Pas de animation aan, aan de snelheid
        anim.SetFloat("y", agent.desiredVelocity.magnitude);
    }

    [SerializeField] public ParticleSystem sneezeEffect = null;
    void attack()
    {
        if (lastAttack.AddSeconds(3) < DateTime.Now) // Hij telt 3 seconden, en alleen als de attack langer dan 3 seconden geleden is kan je aanvallen
        {

        
            sneezeEffect.Play();
            gameManager.playerHealth.health -= 1;
            lastAttack = DateTime.Now; // Reset de timer

            Debug.Log("Sneeze = " + sneezeEffect);
        }
     
    }




    void FaceTarget()
    {
        // Get direction to the target
        Vector3 direction = (target.position - transform.position).normalized;

        // Get rotation where we point to the target
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        // Update own direction to point to this direction
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRadius);

    }
}
