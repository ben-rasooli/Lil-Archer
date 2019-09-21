using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class FlyingTargetController : MonoBehaviour
    {
        [SerializeField] Transform shootingOrigin;
        StatsManager _statsManager;
        bool _flying;
        public float flyingSpeed;
        public float fallingSpeed;
        // Start is called before the first frame update
        void Start()
        {
            _statsManager = FindObjectOfType<StatsManager>();
            _flying = true;
        }

        // Update is called once per frame
        void Update()
        {
            if(_flying)
            {
                transform.position += transform.right * flyingSpeed;
            }
            else
            {
                transform.position -= transform.up * fallingSpeed;
                if (transform.position.y <= 0)
                    gameObject.SetActive(false);
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Arrow")
            {
                _statsManager.OnFlyingTargetHit(this);
                _flying = false;
            }
        }
    }
}
