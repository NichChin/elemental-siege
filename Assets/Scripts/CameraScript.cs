using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{   
    // Fields/Variables to use

    // How fast camera moves when using arrow key input
    public float arrowSpeed = 10.0f;

    // How fast camera moves when using left-click drag
    public float dragSpeed = 5.0f;

    // For updating camera position based on dragging the mouse
    private Vector3 dragPosition;

    // For setting the starting position of the camera to be center of the map
    private Vector3 startPosition = new Vector3(0, 1, 5);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
    }

    public void HandleKeyBoardMovement()
    {   
        // Get the W,A,S,D input from keyboard via Input.GetAxis("Horizontal"), 
        // multply by arrowSpeed to indicate how fast camera should moves when 
        // W,A,S,D is pressed multiply by Time.deltaTime so that camera moves 
        // depending on frame rate, not how fast your pc is
        float moveX = Input.GetAxis("Horizontal") * arrowSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * arrowSpeed * Time.deltaTime;

        // Now that we have acquired new positions for X and Z positions
        // Since Vector3(x, y, z), we want to refer to camera's transform component
        // and move it according to the new input. The translate method is apart of the transform
        // component, which takes in two arguments, Translate(new Vector3(x, y , z), Space.World)
        // Space.World, not Space.Self as we want camera to move according to the world's coordinate system, not ourself

        transform.Translate(new Vector3(moveX, 0, moveZ), Space.World);
    }

    public void HandleMouseDrag() 
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Constantly call 2 helper functions to detect camera movement of arrow keys/mouse drag
        HandleKeyBoardMovement();
        HandleMouseDrag();
    }
}
