using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{

    public Transform InitPos;

    private void Update()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(InitPos.position, transform.TransformDirection(Vector3.forward), out hit,100,layerMask))
        {
            Debug.DrawRay(InitPos.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            if (hit.collider.gameObject.tag.Contains("all"))
            {
                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        else
        {
            Debug.DrawRay(InitPos.position, transform.TransformDirection(Vector3.forward) * 50, Color.red);
            Debug.Log("Did not Hit");
        }
    }


    //for reference only
    //Vector3 temp;
    //temp = transform.position;
    //    Mathf.Clamp(temp.x, 0, 10);
    //    Mathf.Clamp(temp.z, 0, 10);
    //    transform.position = temp;
}
