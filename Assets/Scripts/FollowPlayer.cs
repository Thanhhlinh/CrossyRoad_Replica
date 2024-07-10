using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offSet;
    [SerializeField] private float smoothness;
    
    void Update()
    {
        if(target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position + offSet, smoothness);
        }
    }
}
