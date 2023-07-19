using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float Health = 100;
    public float DamageAmountPerBullet = 5f;
    public GameObject HitEffect;
    public GameObject DieEffect;

    private void Start()
    {
        //EventManager.myEventCaller += EventListner;
    }

    void EventListner()
    {
        //if(Vector3.Distance(transform.position, GameObject.FindObjectOfType<PlayerController>().transform.position) <= 10)
        //{
        //    Instantiate(DieEffect, transform.position, Quaternion.identity);
        //    Destroy(this.gameObject);
        //}
    }

    public void Damage()
    {
        if(Health > 0)
        {
            Health -= DamageAmountPerBullet;
        }
        if(Health <= 0)
        {
            Health = 0;
            Instantiate(DieEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void OnDisable()
    {
        //EventManager.myEventCaller -= EventListner;
    }
}
