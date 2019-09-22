/*
 * Code made by Jack based on code created by Benham
 * 
 * Creates targets with movement and adds new boolean 
 * descriptor of flying or not
 */
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Project
{
    public class FlyingTargetController : MonoBehaviour
    {
        [SerializeField] Transform _shootingOrigin;
        StatsManager _statsManager;
        TextMeshProUGUI _textUI;
        bool _flying;
        public float flyingSpeed;
        public float fallingSpeed;

        void Start()
        {
            _statsManager = FindObjectOfType<StatsManager>();
            _flying = true;
            _textUI = GetComponentInChildren<TextMeshProUGUI>();
            _textUI.text = String.Format("{0:0.00}", (_shootingOrigin.position - transform.position).magnitude) + "m";
        }

        void Update()
        {

            //Checks to see if target is still allowed to fly
           
            if(_flying)
            { 
                //If so target moves to the targets's objective right as determined speed
                transform.position += transform.right * flyingSpeed;
            }
            
            else
            {
                //If not plummets literally to death
                transform.position -= transform.up * fallingSpeed;
                
                //Checks height of target
                if (transform.position.y <= 5)
                    //If below Y = 5 sets target to be deactive
                    gameObject.SetActive(false);
            }
        }

        //Activates upon collision
        void OnCollisionEnter(Collision collision)
        {
            //Ensures the collision is with an arrow
            if (collision.gameObject.tag == "Arrow")
            {
                //Checks to see if the target is still flying around player
                if (_flying == true)
                {
                    //Runs flying targets stat manager's OnHit script adding to the players score
                    _statsManager.OnFlyingTargetHit(this);
                    //Sets targets flying to falling
                    _flying = false;
                }
                else
                    return;                
            }
        }
    }
}
