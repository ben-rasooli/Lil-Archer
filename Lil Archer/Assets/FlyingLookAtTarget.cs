using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingLookAtTarget : MonoBehaviour
{
    [SerializeField] Transform _target;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(_target.position - transform.position);
    }
}
