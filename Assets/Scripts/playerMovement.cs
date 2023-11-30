using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //Collider
    private Collider coll;
    private float collHeight = 0;

    //Object variables
    public Rigidbody rb;

    //Checks variables
    private bool isGrounded;

    //Movement variables
    private float movementSpeed = 50f;
    private float jumpForce = 100;
    public float speedUp;
    public float speedUp2 = 0.1f;

    //Camera variables
    public float lookSpeed = 3;
    private Vector2 rotation = Vector2.zero;

    void Start()
    {
        coll = GetComponent<Collider>();
        //Lock the cursor within the game and set the rigibody
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Every frame call out these functions
        Look();
        Jump();
        PlayerMovement();
        if (!isGrounded)
        {
            speedUp2 += Time.deltaTime * 4;
            speedUp = speedUp - speedUp2 * Time.deltaTime;
            rb.AddForce(0, speedUp, 0);
        }
        if (isGrounded)
        {
            speedUp = 0;
            speedUp2 = 0.1f;
            rb.AddForce(0, speedUp, 0);
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (collHeight < 50)
            {
                collHeight += Time.deltaTime;
                coll.transform.Translate(Vector3.down * collHeight * Time.deltaTime);
            }

        }
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            if (collHeight > 0)
            {
                //collHeight -= Time.deltaTime;
                //coll.transform.Translate(Vector3.down * Time.deltaTime * 5f);
            }
        }
    }
    public void Look() // Look rotation (UP down is Camera) (Left right is Transform rotation)
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -30f, 30f);
        transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
    }
    void PlayerMovement()
    {
        // Vertical and Horizontal Movement

        float facing = Camera.main.transform.eulerAngles.y; // Getting the angle the camera is facing

        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        Vector3 myInputs = new Vector3(horizontalMovement, 0, verticalMovement);

        // we rotate them around Y, assuming your inputs are in X and Z in the myInputs vector
        Vector3 myTurnedInputs = Quaternion.Euler(0, facing, 0) * myInputs;
        rb.MovePosition(transform.position + myTurnedInputs * movementSpeed * Time.deltaTime);
    }
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(UnityEngine.Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            isGrounded = false;
        }
    }
    public void ResetGravity()
    {
        rb = GetComponent<Rigidbody>();
        speedUp = 0;
        speedUp2 = 0.1f;
        rb.AddForce(0, speedUp, 0);
    }
}
