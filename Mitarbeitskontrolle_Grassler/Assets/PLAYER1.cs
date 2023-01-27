using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER1 : MonoBehaviour
{
    public float accel;
    
    Rigidbody Player1;
    // Start is called before the first frame update
    void Start()
    {
        Player1 = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        AddSpeed();
        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0,rotation,0));

        Vector3 velocity = Player1.velocity;

        float direction = Vector3.Dot(transform.forward, velocity.normalized);

        if(direction>0)
        {
            velocity = transform.forward * velocity.magnitude;
        }
        if (direction < 0)
        {
            velocity = -transform.forward * velocity.magnitude;
        }

        Player1.velocity = velocity;
    }

    void AddSpeed()
    {
        float inputForward = Input.GetAxis("Vertical");
        Player1.AddForce(transform.forward * accel * inputForward);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Player1.AddForce(transform.forward * (accel) * inputForward);
        }
    }
}
