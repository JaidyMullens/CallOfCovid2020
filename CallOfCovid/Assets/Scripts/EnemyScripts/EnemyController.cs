using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public int maxArmor = 4;
    public int currentArmor;

    Transform target;
    NavMeshAgent agent;

    public Armor armor;

    GameManager gameManager;

    Transform particleJoint;

    // Animation
    Animator anim;

    float distance;
    void Start()
    {
        
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        //agent.baseOffset = false;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        particleJoint = this.transform.Find("ParticleJoint");

        anim = this.GetComponent<Animator>();
        //armor
        currentArmor = 0;
        armor.SetArmor(currentArmor);
    }

    public float attackRadius = 5f;

    private DateTime lastAttack = DateTime.Now;

    void Update()
    {
 
        

        if (target != null)
        {
            distance = Vector3.Distance(target.position, transform.position);
            anim.SetFloat("y", agent.desiredVelocity.magnitude);
            if (distance <= lookRadius)
            {
                //this.GetComponent<SkinnedMeshRenderer>().material.name = "eyes";
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

        }
       
     
        // For the particle system
        sneezeEffect.transform.position = particleJoint.position;
        sneezeEffect.transform.rotation = particleJoint.rotation;

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("arrow"))
        {
            //this.anim.enabled = false;
            Debug.Log("Collided with arrow!");
            this.anim.enabled = false;
            target = null;
            this.GetComponent<CapsuleCollider>().enabled = false;
            this.GetComponent<NavMeshAgent>().enabled = false;
           
        }
    }

    [SerializeField] public ParticleSystem sneezeEffect = null;
    void attack()
    {
        if (lastAttack.AddSeconds(3) < DateTime.Now) // Hij telt 3 seconden, en alleen als de attack langer dan 3 seconden geleden is kan je aanvallen
        {

        
            sneezeEffect.Play();
            if(currentArmor > 0)
            {
                currentArmor -= 1;
                armor.SetArmor(currentArmor);
            }
            else
            {
                gameManager.playerHealth.health -= 1;
            }
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
