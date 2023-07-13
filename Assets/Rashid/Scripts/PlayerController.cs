using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        //{
        //    // Move the object Right along its z axis 1 unit/second.
        //    transform.Translate(Vector3.right * Speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{

        //    transform.Translate(-Vector3.right * Speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    // Move the object forward along its z axis 1 unit/second.
        //    transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{

        //    transform.Translate(Vector3.back * Speed * Time.deltaTime);
        //}

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * Speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
