using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using static UnityEditor.ShaderData;
public class PlayerController : MonoBehaviour
{
    // Fields
    [Header("Player Stats")]
    [Tooltip("Movement speed of the player in meters per second.")]
    [SerializeField] float speed;
    [Tooltip("Camera look sensitivity.")]
    [SerializeField] float sensitivity;
    [Tooltip("Player sprint speed in meters per second.")]
    [SerializeField] float sprintSpeed;

    [SerializeField] float jumpForce;
    [SerializeField] float gravity;

    // Used to store the forward and backward movement input.
    private float moveFB;
    // Used to store the right and left movement input.
    private float moveLR;
    // Used to store the mouse right and left input.
    private float rotX;
    // Used to store the mouse up and down input.
    private float rotY;

    private Vector3 jumpVeloctity = Vector3.zero;

    // References
    // Reference to the player's vision camera.
    private Camera playerCam;
    // Reference to the CharacterController component on the Player.
    private CharacterController cc;
    void Start()
    {
        
Cursor.lockState = CursorLockMode.Locked;
        
        cc = GetComponent<CharacterController>();
        
        playerCam = transform.GetChild(0).GetComponent<Camera>();
    }
    void Update()
    {
        // Check every frame for movement input and apply the movement.
        Move();
    }
    
private void Move()
    {
        // Local variable to keep track of the current movement speed.
        float movementSpeed = speed;
        // Check to see if the Left Shift key is being held down.
        if (Input.GetKey(KeyCode.LeftShift))
        { 
          movementSpeed = sprintSpeed;
        }
        
else
        {
           
            movementSpeed = speed;
        }
      
        moveFB = Input.GetAxis("Vertical") * movementSpeed;
    
        moveLR = Input.GetAxis("Horizontal") * movementSpeed;
 
        rotX = Input.GetAxis("Mouse X") * sensitivity;
     
rotY -= Input.GetAxis("Mouse Y") * sensitivity;
        // Clamp the value of rotY between -60 degrees and +60 degrees.
        rotY = Mathf.Clamp(rotY, -60f, 60f);
       


// Finally, we multiply by the movementSpeed to get our distance.
Vector3 movement = new Vector3(moveLR, 0, moveFB).normalized *
movementSpeed;

        transform.Rotate(0, rotX, 0);
 
playerCam.transform.localRotation = Quaternion.Euler(rotY, 0, 0);
     
movement = transform.rotation * movement;

        if (cc.isGrounded)
        {
            if (jumpVeloctity.y < 0)
            {
                jumpVeloctity.y = -2f;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpVeloctity.y = jumpForce;
            }
        }
        if (!cc.isGrounded)
        {
            jumpVeloctity.y -= gravity * Time.deltaTime;
        }

        cc.Move(movement + jumpVeloctity * Time.deltaTime);
    }
}
