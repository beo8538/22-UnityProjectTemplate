/**** 
 * Created by: Betzaida Ortiz Rivas
 * Date Created: March 7, 2022
 * 
 * Last Edited by: NA
 * Last Edited:
 * 
 * Description: Player IS the camera
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] Transform playerCamera = null; //game designer puts camera in here for FP view
    [SerializeField] float mouseSensitivity = 3.5f; //speed of mouse movement
    [SerializeField] bool cursorLock = true; //locks cursor in place
    [SerializeField] float walkSpeed = 6.0f; //movement of player speed
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f; //smooth move
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f; //smooth out the mouse movement

    float cameraPitch = 0.0f;
    CharacterController controller = null;

    Vector2 currDirection = Vector2.zero; //stores current direction of player
    Vector2 currDirVelocity = Vector2.zero; //stores the velocity of current direction
    Vector2 currMouseDelta = Vector2.zero;
    Vector2 currMouseDeltaVelocity = Vector2.zero; //speed mouse

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked; //locks cursor
            //Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouseLook(); //method for movement of camera with mouse
        UpdateMovement(); //method that moves player (WASD)
    }

    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")); //gets the axis of x and y for mouse

        currMouseDelta = Vector2.SmoothDamp(currMouseDelta, targetMouseDelta, ref currMouseDeltaVelocity, mouseSmoothTime); //smooth time

        cameraPitch -= currMouseDelta.y * mouseSensitivity; //rotates camera to look up and down
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f); // makes sure the player only look up and down and not invert camera

        playerCamera.localEulerAngles = Vector3.right * cameraPitch; //rotates right vector by cameraPitch

        transform.Rotate(Vector3.up * currMouseDelta.x * mouseSensitivity); // rotates camera to look left and right
    }

    void UpdateMovement()
    {
        Vector2 targetDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //get each direction (front and back, side to side)
        targetDirection.Normalize(); //make sure player speed when going diagonal is same as going forward

        currDirection = Vector2.SmoothDamp(currDirection, targetDirection, ref currDirVelocity, moveSmoothTime); //smooths out the suddent movements when turning

        Vector3 velocity = (transform.forward * currDirection.y + transform.right * currDirection.x) * walkSpeed;

        controller.Move(velocity * Time.deltaTime); //apply velocity to controller


    }
}
