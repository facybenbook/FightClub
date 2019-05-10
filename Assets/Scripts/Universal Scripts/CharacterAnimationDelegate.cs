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
    private AudioClip whooshSound, fallSound, groundHitSound, deadSound;

    private EnemyMovement enemyMovement;

    private ShakeCamera shakeCamera;

    void Awake()
    {
        animationScript = GetComponent<CharacterAnimation>();

        audioSource = GetComponent<AudioSource>();

        if(gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            enemyMovement = GetComponentInParent<EnemyMovement>();
        }
        shakeCamera = GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<ShakeCamera>();
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


    // SOUNDS
    public void AttackFXSound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = whooshSound;
        audioSource.Play();
    }

    void CharacterDiedSound()
    {
        audioSource.volume = 1f;
        audioSource.clip = deadSound;
        audioSource.Play();
    }

    void EnemyKnockedDown()
    {
        audioSource.clip = fallSound;
        audioSource.Play();
    }

    void EnemyHitGround()
    {
        audioSource.clip = groundHitSound;
        audioSource.Play();
    }

    void DisableMovement()
    {
        enemyMovement.enabled = false;

        // set the enemy parent to defualt layer
        transform.parent.gameObject.layer = 0;
    }
     
    void EnableMovement()
    {
        enemyMovement.enabled = true;

        // set the enemy parent to ebemy layer
        transform.parent.gameObject.layer = 10;
    }

    void ShakeCameraOnFall()
    {
        shakeCamera.ShouldShake = true;
    }

    void CharacterDied()
    {
        Invoke("DeactivateGameObject", 2f);
    }

    void DeactivateGameObject()
    {
        EnemyManager.instance.SpawnEnemy();
        gameObject.SetActive(false);
    }
}
