using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowerEnemyMovement : MonoBehaviour,IEnemyMovement
{
    

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    private Animator animator;
    private List<string> resetParameters=new List<string>();


    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    //public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public GameData gameData;

    [SerializeField] private bool isTeleporter;

    
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator=GetComponent<Animator>();
    }

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnInvulnerable,OnPlayerInvulnerable);
        EventManager.AddHandler(GameEvent.OnVulnerable,OnPlayerVulnerable);
        EventManager.AddHandler(GameEvent.OnTimeStop,OnTimeIsStop);
        EventManager.AddHandler(GameEvent.OnTimeContinue,OnTimeIsContinue);
        
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnInvulnerable,OnPlayerInvulnerable);
        EventManager.RemoveHandler(GameEvent.OnVulnerable,OnPlayerVulnerable);
        EventManager.RemoveHandler(GameEvent.OnTimeStop,OnTimeIsStop);
        EventManager.RemoveHandler(GameEvent.OnTimeContinue,OnTimeIsContinue);
    }

    private void Update()
    {
        if(!gameData.stopEnemies)
            Movement();
    }

    public void Movement()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    void OnPlayerInvulnerable()
    {
        attackRange=2;
    }

    void OnPlayerVulnerable()
    {
        attackRange=0.5f;
    }

    void OnTimeIsStop()
    {
        animator.SetBool("Idle",true);
        animator.SetBool("Run",false);
        animator.SetBool("Attack",false);
        agent.speed=0;
    }

    void OnTimeIsContinue()
    {
        if(isTeleporter)
            agent.speed=2;
        else
            agent.speed=5;
    }

    private void Patroling()
    {
        animator.SetBool("Idle",true);
        animator.SetBool("Run",false);
        animator.SetBool("Attack",false);

        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;


        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        animator.SetBool("Run",true);
        animator.SetBool("Attack",false);
        animator.SetBool("Idle",false);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        animator.SetBool("Attack",true);
        animator.SetBool("Run",false);
        animator.SetBool("Idle",false);

        transform.LookAt(player);
        Debug.Log("ATTACK ATTACK");

        if (!alreadyAttacked)
        {
            
            ///Attack code here
            /*Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);*/
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    

  
}
