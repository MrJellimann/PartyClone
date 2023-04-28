using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementControls : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 1f;
    [SerializeField]
    private float jumpHeight = 4f;
    [SerializeField]
    private float gravity = -8f;
    [SerializeField]
    private float jumpSpeed = 0f;
    [SerializeField]
    private CharacterController characterController = null;

    private void Awake()
    {
        if (characterController == null)
            characterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        
        if (characterController.isGrounded)
        {
            jumpSpeed = 0f;

            if (Input.GetButton("Jump"))
            {
                jumpSpeed = jumpHeight;
            }
        }

        if (jumpSpeed > -gravity)
            jumpSpeed -= gravity * Time.deltaTime;


        Vector3 moveVector = new Vector3(horz * maxSpeed * Time.deltaTime, jumpSpeed * Time.deltaTime, vert * maxSpeed * Time.deltaTime);

        characterController?.Move(moveVector);
    }
}
