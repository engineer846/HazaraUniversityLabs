using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 100f;
       // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision Other)
    {
        if(Other.collider.tag.Contains("Wall")){
            Destroy(this.gameObject);
        }

        //if (Other.collider.tag.Contains("Opponent"))
        //{
        //    Destroy(Other.collider.gameObject);
        //    Destroy(this.gameObject);
        //}

        HealthController health = Other.collider.GetComponent<HealthController>();

        if (health != null)
        {
            //damage
            if(health.HitEffect != null)
            {
                Instantiate(health.HitEffect, transform.position, Quaternion.identity);
            }
            health.Damage();
            Destroy(this.gameObject);
        }

    }
}
