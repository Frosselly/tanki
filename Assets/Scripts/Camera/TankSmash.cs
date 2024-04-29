using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSmash : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(20, 80), Random.Range(20, 80), Random.Range(20, 80));
        }
    }
}
