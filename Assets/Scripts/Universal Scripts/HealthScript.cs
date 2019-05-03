using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;

    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;

    private bool characterDied;

    public bool isPlayer;

    void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();
    }

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (characterDied)
            return;

        health -= damage;

        // display Health UI
        if(health <= 0f)
        {
            animationScript.Death();
            characterDied = true;

            if(isPlayer)
            {

            }

            return;
        }

        if(!isPlayer)
        {
            if(knockDown)
            {
                if(Random.Range(0, 2) > 0)
                {
                    animationScript.KnockDown();
                }
            } else
            {
                if(Random.Range(0, 3) > 1)
                {
                    animationScript.Hit();
                }
            }
        }
    }

}
