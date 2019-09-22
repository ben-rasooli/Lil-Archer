/*
 * Code written by Jack based off code by Behnam
 * 
 * Rotates target to look at player working in
 * cohesion with FlyingTargetController to make
 * targets that fly around the tower
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingLookAtTarget : MonoBehaviour
{
    [SerializeField] Transform _player;

    void Update()
    {
        //Sets rotation to face player every frame
        transform.rotation = Quaternion.LookRotation(_player.position - transform.position);
    }
}
