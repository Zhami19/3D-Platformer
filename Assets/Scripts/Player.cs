using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed = 1;

    [SerializeField]
    float jumpForce = 1;

    [SerializeField]
    float gravity = 1;

    CharacterController controller;

    Vector3 movement;

    bool grounded;

    [SerializeField]
    Transform myCamera;

    [SerializeField]
    PlayerStats myStats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        myStats.health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -10)
        {
            SceneManager.LoadScene(2);
        }

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector3 canForward = myCamera.forward;
        Vector3 canRight = myCamera.right;

        canForward.y = 0;
        canForward.Normalize();

        canRight.y = 0;
        canRight.Normalize();

        Vector3 forwardRelativeMovement = yInput * canForward;
        Vector3 rightRelativeMovement = xInput * canRight;

        var relativeMovement = (forwardRelativeMovement + rightRelativeMovement) * speed;

        if (xInput != 0 || yInput != 0)
        {
            transform.forward = relativeMovement;
        }

        relativeMovement.y = movement.y;
        movement = relativeMovement;

        movement.y += gravity * Time.deltaTime;

        if(controller.isGrounded)
        {
            movement.y = 0;
        }

        grounded = (Physics.Raycast(transform.position + Vector3.down, Vector3.down, 1));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            movement.y = jumpForce;
        }

        controller.Move(movement * Time.deltaTime);     
    }

    public void Damage()
    {
        Debug.Log("Damage taken");
        myStats.health -= 20f;

        if (myStats.health == 0f)
        {
            SceneManager.LoadScene(2);
        }
    }
}
