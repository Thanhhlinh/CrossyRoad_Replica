using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private float speed;
    public bool isLog;
    private void Update()
    {
        if (transform.position.z > 55)
        {
            Destroy(gameObject);
        }else if (transform.position.z < -55)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

   /* private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Player>() != null)
        {
            Destroy(collision.gameObject);
        }
    }*/
}
