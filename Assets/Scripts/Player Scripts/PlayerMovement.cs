using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // animate the gameobject
    // private PlayerAnimation player_Animation;

    private Rigidbody myBody;

    public float walkSpeed = 2f;
    public float zSpeed = 1.5f;

    private float yRotation = -90f;
    private float rotationSpeed = 15f;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        // player_Animation = GetComponentInChildren<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        //print("The value is: " + Input.GetAxisRaw("HORIZONTAL_AXIS);
        RotatePlayer();
    }

    // used to move the body
    private void FixedUpdate()
    {
        DetectMovement();
    }

    void DetectMovement()
    {
        myBody.velocity = new Vector3(
            Input.GetAxisRaw("Horizontal") * (-walkSpeed),
            myBody.velocity.y,
            Input.GetAxisRaw("Vertical") * (-zSpeed));
    }

    // the player's rotation.
    void RotatePlayer()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0f, -Mathf.Abs(yRotation), 0f);
        } else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(yRotation), 0f);

        }
    }
}
