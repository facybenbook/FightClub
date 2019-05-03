using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{

    public GameObject leftArmAttackPoint, rightArmAttackPoint,
        leftLegAttackPoint, rightLegAttackPoint;

    public float standUpTimer = 2f;

    private CharacterAnimation animationScript;

    // audio source
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip wooshSound, fallSound, groundHitSound, deadSounnd;

    private EnemyMovement enemyMovement;


    void Awake()
    {
        animationScript = GetComponent<CharacterAnimation>();

        audioSource = GetComponent<AudioSource>();

        if(gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            enemyMovement = GetComponentInParent<EnemyMovement>();

        }
    }

    // ARMS
    void leftArmAttackOn()
    {
        leftArmAttackPoint.SetActive(true);
    }

    void leftArmAttackOff()
    {
        if (leftArmAttackPoint.activeInHierarchy)
        {
            leftArmAttackPoint.SetActive(false);
        }
    }

    void rightArmAttackOn()
    {
        rightArmAttackPoint.SetActive(true);
    }

    void rightArmAttackOff()
    {
        if (rightArmAttackPoint.activeInHierarchy)
        {
            rightArmAttackPoint.SetActive(false);
        }
    }

    // LEGS
    void leftLegAttackOn()
    {
        leftLegAttackPoint.SetActive(true);
    }

    void leftLegAttackOff()
    {
        if (leftLegAttackPoint.activeInHierarchy)
        {
            leftLegAttackPoint.SetActive(false);
        }
    }

    void rightLegAttackOn()
    {
        rightLegAttackPoint.SetActive(true);
    }

    void rightLegAttackOff()
    {
        if (rightLegAttackPoint.activeInHierarchy)
        {
            rightLegAttackPoint.SetActive(false);
        }
    }

    void TagLeftArm()
    {
        leftArmAttackPoint.tag = Tags.LEFT_ARM_TAG;
    }

    void UnTagLeftArm()
    {
        leftArmAttackPoint.tag = Tags.UNTAGGED_TAG;
    }

    void TagLeftLeg()
    {
        leftArmAttackPoint.tag = Tags.LEFT_LEG_TAG;
    }

    void UnTagLeftLeg()
    {
        leftArmAttackPoint.tag = Tags.UNTAGGED_TAG;
    }

    void EnemyStandUp()
    {
        StartCoroutine(StandUpAfterTime());
    }

    IEnumerator StandUpAfterTime()
    {
        yield return new WaitForSeconds(standUpTimer);
        animationScript.StandUp();
    }
}
