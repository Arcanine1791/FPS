using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum EnemyStates {Patrol, Chase, Attack}

    [SerializeField] EnemyStates EnemyCurrentState;

    [SerializeField] GameObject player;

    [SerializeField] GameObject[] wayPoints;
    GameObject TargetWayPoint;
    int wpIndex;

    [SerializeField] float patrolSpeed;

    [SerializeField] float chaseDistance;
    [SerializeField] float chaseSpeed;

    [SerializeField] float attackRange;

    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        EnemyCurrentState = EnemyStates.Patrol;
        TargetWayPoint = wayPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = Vector3.Distance(this.transform.position, player.transform.position);

        if(Distance < chaseDistance)
        {
            if(Distance > attackRange)
            {
                EnemyCurrentState = EnemyStates.Chase;
            }

            else
            {
                EnemyCurrentState = EnemyStates.Attack;
            }
        }

        else
        {
            EnemyCurrentState = EnemyStates.Patrol;
        }

        switch(EnemyCurrentState)
        {
            case EnemyStates.Patrol:
                Patrolling();
                break;

            case EnemyStates.Chase:
                Chasing();
                break;

            case EnemyStates.Attack:
                Attack();
                break;
        }
    }

    void Patrolling()
    {
        float distance = Vector3.Distance(this.transform.position, TargetWayPoint.transform.position);

        if(distance <= 0.5f)
        {
            if (wpIndex == wayPoints.Length - 1)
            {
                wpIndex = 0;
            }

            else
            {
                wpIndex++;
            }

            TargetWayPoint = wayPoints[wpIndex];
        }

        this.transform.LookAt(TargetWayPoint.transform.position);
        this.transform.position = Vector3.MoveTowards(this.transform.position, TargetWayPoint.transform.position, patrolSpeed * Time.deltaTime);
        anim.SetBool("Patrol", true);
    }

    void Chasing()
    {
        this.transform.LookAt(player.transform.position);
        this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, chaseSpeed * Time.deltaTime);
        anim.SetBool("Patrol", false);
        anim.SetBool("Chase", true);
    }

    void Attack()
    {
        anim.SetBool("Chase", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, chaseDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRange);
    }
}
