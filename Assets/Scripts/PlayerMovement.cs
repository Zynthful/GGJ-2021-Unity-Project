using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] GameObject camera;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float L_E_A_N_MULTIPLIER;

    Rigidbody rb;

    float xInput;
    float yInput;

    [SerializeField] bool doLean;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(camera == null)
        {
            //camera = Camera.main.gameObject;
        }
    }

    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        Jump();
    }

    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        rb.velocity = ((xInput * transform.right)+(yInput * transform.forward)) * moveSpeed;
    }

    void Rotate()
    {
        if(doLean)
        {
            Vector3 rotationValues = rb.velocity.normalized * L_E_A_N_MULTIPLIER;

            camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, Quaternion.Euler(rotationValues.z, camera.transform.eulerAngles.y, -rotationValues.x), 0.1f);
        }

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, camera.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
    
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector3.down, Color.red, 1);
            if(Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector3.down, 1200.5f, layerMask:default)){rb.AddForce(0, jumpForce, 0);}
        }
    }
}
