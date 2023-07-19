using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed = 200f;

    [Header("Shooting Area")]
    public GameObject BulletPrefab;
    public Transform BulletInitPos;
    public float fireRate = 0.1f;
    private float lastShot = 0f;

    [Header("Animations Area")]
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        //Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        //float magnitude = moveDirection.magnitude;
        //if (moveDirection != Vector3.zero)
        //{
        //    Quaternion toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, RotationSpeed * Time.deltaTime);
        //}

        //transform.Translate(transform.forward * magnitude * Speed * Time.deltaTime, Space.World);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = moveDirection.magnitude;

        if (magnitude > 0.01f) // Consider using a small threshold for magnitude instead of Vector3.zero check
        {
            Quaternion toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, RotationSpeed * Time.deltaTime);
        }

        transform.Translate(moveDirection.normalized * magnitude * Speed * Time.deltaTime, Space.World);

        if (Input.GetMouseButton(0))
        {
            //Fire
            FireBullet();
        }
    }

    void FireBullet()
    {
        if (Time.time > fireRate + lastShot)
        {
            Instantiate(BulletPrefab, BulletInitPos.position, BulletInitPos.rotation);
            lastShot = Time.time;
            EventManager.myEventCaller();
            anim.SetTrigger("Shoot");
        }
    }
}
