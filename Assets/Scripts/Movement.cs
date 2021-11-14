using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] Vector3 movementTransform;
    CharacterController characterController;
    PlayerInputController playerInputController;
    Vector3 movementValue;
    Vector2 readingValue;
    [SerializeField] float speed = 2f;
    [SerializeField] float forwardSpeed = 2f;

    [SerializeField] GameObject plane;
    [SerializeField] GameObject playerModel;
    // Start is called before the first frame update
    //Animator animator;
    float minSpeed = 2f;
    float maxSpeed = 4f;

    private void Awake()
    {
        Debug.Log("Awake");
        playerInputController = new PlayerInputController();
        characterController = GetComponent<CharacterController>();
        playerInputController.CharacterControls.Move.started += movementInput;
        playerInputController.CharacterControls.Move.performed += movementInput;
        playerInputController.CharacterControls.Move.canceled += movementInput;

       // animator = playerModel.GetComponent<Animator>();
    }
    void Start()
    {
        Debug.Log("Started");

    }

    // Update is called once per frame
    void Update()
    {

        characterController.Move((movementValue + new Vector3(0.0f, 0.0f, forwardSpeed)) * Time.deltaTime * speed);
        /*
        if (animator.GetBool("isWalking"))
        {
            speed = Mathf.Clamp(speed + Time.deltaTime, minSpeed, maxSpeed);
            if(!animator.GetBool("isRunning") && speed > 3.5f)
            {
                animator.SetBool("isRunning", true);
            } else
            {
                speed = minSpeed;
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);
            }
        }
        */

      //  animator.SetFloat("Blend", (speed - minSpeed) / 2f);
        /*
         * if (!animator.GetBool("isRunning") && speed > 3.5f)
        {
            animator.SetBool("isRunning", true);
        }
        */
    }

    void movementInput(InputAction.CallbackContext context)
    {

        readingValue = context.ReadValue<Vector2>();
        movementValue.x = readingValue.x;
        movementValue.y = gravityControl();
        movementValue.z = readingValue.y;
        /*
        if (readingValue.x != 0f || readingValue.y != 0f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        */
        Debug.Log(readingValue);
    }

    private void OnEnable()
    {
        playerInputController.Enable();
    }

    private void OnDisable()
    {
        playerInputController.Disable();
    }

    float gravityControl()
    {
        if (characterController.isGrounded)
        {
            float gravityRate = -0.1f;
            return gravityRate;
        }
        else
        {
            float gravityRate = -9.8f;
            return gravityRate;
        }
    }
}
