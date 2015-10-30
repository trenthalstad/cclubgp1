using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour {


    //public float m_Speed = 3f;
    public float m_TurnSpeed = 180f;
    public float r_Speed = 3f;
    public float r_TurnSpeed = 180f;
    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue;
    private float r_MovementInputValue;
   
    private float r_TurnInputValue1;
    private float m_TurnInputValue2;
    private string r_MovementAxisName;
    private string m_MovementAxisName;
    private string m_TurnAxisName;



    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
   // private void OnEnable()
    //{
     //   m_Rigidbody.isKinematic = false;
     //   m_MovementInputValue = 0f;
     //   m_TurnInputValue1 = 0f;
     //   m_TurnInputValue2 = 0f;
 //   }

   // private void OnDisable()
    //{
      //  m_Rigidbody.isKinematic = true;
   // }

    private void Start ()
    {
        r_MovementAxisName = "Vertical";
        m_TurnAxisName = "Horizontal";

    }

    private void Update ()
    {
        r_MovementInputValue = Input.GetAxis(r_MovementAxisName);
        //transform.Rotate(0f, m_MovementInputValue*Time.deltaTime, 0f);
        m_TurnInputValue2 = Input.GetAxis(m_TurnAxisName);
    }

    void FixedUpdate()
    {
        //move();
        move2();
        //Turn();

        //m_Rigidbody.AddForce(movement * speed);
    }
    //private void move()
    //{
       //Vector3 movement = new Vector3(0.0f, 0.0f, r_MovementInputValue);
      // m_Rigidbody.AddForce(movement * r_Speed);
    //}

    private void move2()
    {
       
         
     

        float yturn = r_MovementInputValue * m_TurnSpeed * Time.deltaTime;
        Quaternion yturnRotation = Quaternion.Euler(yturn, 0f, 0f);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * yturnRotation);


        float xturn = m_TurnInputValue2 * m_TurnSpeed * Time.deltaTime;
        Quaternion xturnRotation = Quaternion.Euler(0f, xturn, 0f);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * xturnRotation);
        Vector3 move = new Vector3(xturn, 0f, 0f);
        //Vector3 ymovement = new Vector3(0.0f, 0.0f, r_MovementInputValue);
        m_Rigidbody.AddForce(move * r_Speed);


        //Vector3 movement = transform.forward * r_MovementInputValue * r_Speed * Time.deltaTime;
        //float xturn = m_TurnInputValue2 * r_Speed * Time.deltaTime;
        //float yturn = r_MovementInputValue * r_Speed * Time.deltaTime;
        //Quaternion xturnRotation = Quaternion.Euler(0f, xturn, 0f);
        //Quaternion yturnRotation = Quaternion.Euler(yturn, 0f, 0f);
       // m_Rigidbody.MoveRotation(m_Rigidbody.rotation * yturnRotation);
}

    private void Turn ()
    {
        //float turn2 = m_TurnInputValue2 * m_TurnSpeed * Time.deltaTime;
        //Quaternion turnRotation = Quaternion.Euler(0f, turn2, 0f);
        //m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);



    }

}
