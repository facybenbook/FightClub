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

    // displays the health and the changes when the player gets hit
    private HealthUI healthUI;

    void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();
        if(isPlayer)
        {
            healthUI = GetComponent<HealthUI>();
        }
    }

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (characterDied)
            return;

        health -= damage;

        // display Health UI
        if (isPlayer)
        {
            healthUI.DisplayHealth(health);
        }

        if(health <= 0f)
        {
            animationScript.Death();
            characterDied = true;

            if(isPlayer)
            {
                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>().enabled = false;
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
