using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float stupidFuckingVariableFuckYou;
    [SerializeField] private float speed;
    [SerializeField] private float sensitivity;
    [SerializeField] private float sprintSpeed;




    private float moveFB;
    private float moveLR;

    private float rotX;
    private float rotY;

    private Camera playerCam;

    private CharacterController cc;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        cc.GetComponent<CharacterController>();

        playerCam = transform.GetChild(0).GetComponent<Camera>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float movementspeed = speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementspeed = sprintSpeed;
        } else
        {
            movementspeed = speed;
        }

        moveFB = Input.GetAxis("Vertical") * movementspeed;

        moveLR = Input.GetAxis("Horizontal") * movementspeed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;

        rotY -= Input.GetAxis("Mouse Y") * sensitivity;

        rotY = Mathf.Clamp(rotY, -60F, 60F);

        Vector3 movement = new Vector3(moveLR, 0, moveFB).normalized * movementspeed;

        transform.Rotate(0, rotX, 0);

        transform.localRotation = Quaternion.Euler(rotY, 0, 0);

        playerCam.transform.localRotation = Quaternion.Euler(rotY, 0, 0);

        movement = transform.rotation * movement;

        cc.Move(movement * Time.deltaTime);
    }
}
