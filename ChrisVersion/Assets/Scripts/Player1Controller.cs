using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour {

    
    //Start Tank Code
    public float m_Speed = 12f;                 // How fast the tank moves forward and back.
    public float m_TurnSpeed = 180f;            // How fast the tank turns in degrees per second.

    private string m_MovementAxisName;          // The name of the input axis for moving forward and back.
    private string m_TurnAxisName;              // The name of the input axis for turning.
    private Rigidbody m_Rigidbody;              // Reference used to move the tank.
    private float m_MovementInputValue;         // The current value of the movement input.
    private float m_TurnInputValue;             // The current value of the turn input.
    public GameObject Main_Camera;
    public GameObject Player_Cube;
    public GameObject player1;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        // The axes names are based on player number.
        m_MovementAxisName = "Vertical";
        m_TurnAxisName = "Horizontal";
        
    }

    private void Update()
    {
        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);

    }

    

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0F, moveVertical);
        Vector3 movement = Player_Cube.transform.forward;


        m_Rigidbody.AddForce(movement * m_Speed);


        Move();
        Turn();

        // Keeps the Player_Cube object at the same position as the Player1 object
        Player_Cube.transform.position = player1.transform.position;
    }

    private void Move()
    {
        // Create a vector in the direction the cube is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = Player_Cube.transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

        // Apply this movement to the rigidbody's position.
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);


        // What Follows is an attempt to get the object to rotate forward as it rolls
        //float turn = m_MovementInputValue * m_Speed * Time.deltaTime;
        //Quaternion moveRotation = Quaternion.Euler(0f, 0f, turn);
        //m_Rigidbody.MoveRotation(m_Rigidbody.rotation * moveRotation);

    }

    private void Turn()
    {
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply this rotation to the rigidbody's rotation.
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
        
    }

}
