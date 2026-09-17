using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{
    public Vector2 moveInput; 
    public Vector2 moveDirection; //Since project is entirely 2D, it did not make sense to make a Vector 3 for the movement direction
    public Rigidbody rb;
    public float screenLimit;

    public float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Update()
    {
        Vector3 position = transform.position;
        
        position.x = Mathf.Clamp(position.x, -screenLimit, screenLimit); //clamps player movement to screen limits
        //this is just the X coordinates specifically since we are only moving in that plane

        transform.position = position;
    }
    
    
    void FixedUpdate() // Doesn't check for inputs every frame
    {
        Movement();       
    }

    public void OnMove (InputValue value)
    {
        moveInput = value.Get<Vector2>(); //read input as a Vector2
    }

    public void Movement()
    {
        moveDirection = transform.right * moveInput.x; // directions the player moves. Since the player only moves in the x axis, this much is enough.
        rb.linearVelocity = moveDirection * speed;
    }


}
