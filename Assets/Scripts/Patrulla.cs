using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrulla : MonoBehaviour {

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    public Transform target;
    public Transform target2;
    public Transform targetMain;

    private bool isMainTargetClose = false;
    private bool targetState = true;
    private bool damage = false;

    const int countOfDamageAnimations = 3;
    int lastDamageAnimation = -1;

    // Use this for initialization
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Walk();
        changeTarget();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, targetMain.position);
        if (dist < 1)
        {
            isMainTargetClose = true;
        } else
        {
            Walk();
        }
    }

    private void FixedUpdate()
    {
        if (isMainTargetClose)
        {
            Attack();
            if (!damage)
            {
                StartCoroutine(Wait());
            }
        }
    }

    public void changeTarget()
    {
        if (!isMainTargetClose) {
            if (targetState) {
                navMeshAgent.SetDestination(target.position);
                targetState = false;
                Walk();
            }
            else  {
                navMeshAgent.SetDestination(target2.position);
                targetState = true;
                Walk();
            }
        }
    }

    public void changeToMainTarget()
    {
        followToJoe();
        isMainTargetClose = true;
    }

    public void changeToPatrol()
    {
        isMainTargetClose = false;
        changeTarget();
    }

    public void Walk()
    {
        animator.SetBool("Aiming", false);
        animator.SetFloat("Speed", 0.5f);
    }

    public void followToJoe()
    {
        navMeshAgent.SetDestination(targetMain.position);
    }

    public void Attack()
    {
        Aiming();
        animator.SetTrigger("Attack");
    }

    public void Aiming()
    {
        animator.SetBool("Squat", false);
        animator.SetFloat("Speed", 0f);
        animator.SetBool("Aiming", true);
    }

    public void Damage()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Death")) return;
        int id = Random.Range(0, countOfDamageAnimations);
        if (countOfDamageAnimations > 1)
            while (id == lastDamageAnimation)
                id = Random.Range(0, countOfDamageAnimations);
        lastDamageAnimation = id;
        animator.SetInteger("DamageID", id);
        animator.SetTrigger("Damage");
    }

    public void Stay()
    {
        animator.SetBool("Aiming", false);
        animator.SetFloat("Speed", 0f);
    }

    IEnumerator Wait()
    {

        damage = true;
        targetMain.GetComponent<Motor>().Damage();

        yield return new WaitForSeconds(2);
        
        damage = false;
        
    }
}
