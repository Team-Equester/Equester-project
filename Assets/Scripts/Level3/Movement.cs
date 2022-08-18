using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public PlayerInput playerInput;
    public Rigidbody rb;
    private PlayerControl pc;
    private float speed = 5f;
    public GameObject Cubes;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        pc = new PlayerControl();
        pc.Special.Enable();
        pc.Special.Movement.performed += Movement_performed;
    }

    private void FixedUpdate()
    {
        if (Cubes.GetComponent<Movement>().enabled == true)
        {
            Vector2 inputVector = pc.Special.Movement.ReadValue<Vector2>();
            //rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
            //Preferably Better
            Cubes.transform.position += new Vector3(inputVector.x, 0f, inputVector.y) * speed * Time.deltaTime;
        }
    }

    public void Movement_performed(InputAction.CallbackContext context)
    {
        //Debug.Log(context);
        if (gameObject.GetComponent<Movement>().enabled == true)
        {
            Vector2 inputVector = context.ReadValue<Vector2>();
            Cubes.transform.position += new Vector3(inputVector.x, 0f, inputVector.y) * speed * Time.deltaTime;
            //rb.AddForce(new Vector3(inputVector.x,0, inputVector.y) * speed, ForceMode.Force);

        }
    }
}
