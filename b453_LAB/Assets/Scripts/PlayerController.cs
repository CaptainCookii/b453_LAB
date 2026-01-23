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

    [SerializeField] private Pistol heldWeapon;

    private float moveFB;
    private float moveLR;
    private float rotX;
    private float rotY;
    private Vector3 jumpVeloctity = Vector3.zero;

    
    private Camera playerCam;
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
        shoot();
        reload();
        heldWeapon.displayPub();
    }
    
private void Move()
    {
        float movementSpeed = speed;
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
        rotY = Mathf.Clamp(rotY, -60f, 60f);      
        Vector3 movement = new Vector3(moveLR, 0, moveFB).normalized * movementSpeed;
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

    private void shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            heldWeapon.shootPub();
        }
    }

    private void reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            heldWeapon.reloadPub();
        }
    }
}
