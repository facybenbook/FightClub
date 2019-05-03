using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private CharacterAnimation enemyAnim;
    private Rigidbody myBody;

    public float speed = 5f;

    private Transform playerTarget;

    public float attackDistance = 1f;
    private float chasePlayerAfterAttack = 1f;

    private float currentAttackTime;
    private float defaultAttackTime = 2f;

    private bool followPlayer; 
    private bool attackPlayer;

    void Awake()
    {
        enemyAnim = GetComponentInChildren<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();

        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        followPlayer = true;
        currentAttackTime = defaultAttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    // it will follow the player till it gets close to the player.
    void FollowTarget()
    {
        if (!followPlayer)
            return;

        if(Vector3.Distance(transform.position, playerTarget.position) > attackDistance)
        {
            transform.LookAt(playerTarget);
            myBody.velocity = transform.forward * speed;

            if(myBody.velocity.sqrMagnitude != 0)
            {
                enemyAnim.Walk(true);
            }
        } else if(Vector3.Distance(transform.position, playerTarget.position) <= attackDistance)
        {
            myBody.velocity = Vector3.zero;
            enemyAnim.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }
    }


    // enemy will attack the player it reaches close to the player and will stop moving.
    void Attack()
    {
        if (!attackPlayer)
            return;

        currentAttackTime += Time.deltaTime;

        if(currentAttackTime > defaultAttackTime)
        {
            enemyAnim.EnemyAttack(Random.Range(0, 3));
            currentAttackTime = 0f;
        }

        if(Vector3.Distance(transform.position, playerTarget.position) > attackDistance + chasePlayerAfterAttack)
        {
            attackPlayer = false;
            followPlayer = true;
        }
    }
}
