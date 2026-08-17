using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour

{
     //Movement tuning; editable within Inspector)
    public float speed = 5.0f;
    public float turnSpeed = 100f;

    //Input System action that is exposed in Inspector for binding (WASD/Arrow Keys)
    public InputAction MoveAction;
    
    //Current input value (x = left/right, y = forward/back), kept private for internal use
    private Vector2 moveInput;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Enable the MoveAction so it starts reading input 
        MoveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //Read the 2D vector from the MoveAction(x: horizontal, y: vertical)
        moveInput = MoveAction.ReadValue<Vector2>();

        // Move the vehicle forward at 20 meters per second
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);
        
        // Move forward / back along local Z-axis using the y component 
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * moveInput.x);
        
        // Rotate around local Y (yaw) using the x component
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * moveInput.x);
        }    
}

