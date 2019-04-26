using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState {
    NONE,
    PUNCH1,
    PUNCH2,
    PUNCH3,
    KICK1,
    KICK2
}

public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation playerAnim;

    private bool activateTimerToReset;
    private float defaultComboTimer = 0.4f;
    private float currentComboTimer;

    private ComboState currentComboState;

    void Awake()
    {
        playerAnim = GetComponentInChildren<CharacterAnimation>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentComboTimer = defaultComboTimer;
        currentComboState = ComboState.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        ComboAttacks();
        ResetComboState();
    }

    void ComboAttacks()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(currentComboState == ComboState.PUNCH3 ||
                currentComboState == ComboState.KICK1 ||
                currentComboState == ComboState.KICK2)
            {
                return;
            }

            currentComboState++;
            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;

            if(currentComboState == ComboState.PUNCH1)
            {
                playerAnim.Punch1();
            }
            if(currentComboState == ComboState.PUNCH2)
            {
                playerAnim.Punch2();
            }
            if(currentComboState == ComboState.PUNCH3)
            {
                playerAnim.Punch3();
            }
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            if(currentComboState == ComboState.KICK2 ||
                currentComboState == ComboState.PUNCH3)
            {
                return;
            }

            if(currentComboState == ComboState.NONE ||
                currentComboState == ComboState.PUNCH1 ||
                currentComboState == ComboState.PUNCH2)
            {
                currentComboState = ComboState.KICK1;
            } else if(currentComboState == ComboState.KICK1)
            {
                currentComboState++;
            }

            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;

            if(currentComboState == ComboState.KICK1)
            {
                playerAnim.Kick1();
            }
            if(currentComboState == ComboState.KICK2)
            {
                playerAnim.Kick2();
            }
        }
    }


    void ResetComboState()
    {
        if(activateTimerToReset)
        {
            currentComboTimer -= Time.deltaTime;
            if(currentComboTimer <= 0f)
            {
                currentComboState = ComboState.NONE;
                activateTimerToReset = false;
                currentComboTimer = defaultComboTimer;
            }
        }
    }
}
