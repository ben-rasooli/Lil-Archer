using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Project
{
    public class BirdController : MonoBehaviour
    {
        enum EBirdState
        {
            WANDER, // wandering 
            RETRIEVING,//Retrieving the arrow
            RETURNARROW,//returning the arrow to the player
            RETURN//returning to original position
        }
        Rigidbody m_RigidBody;
        [SerializeField] float m_fSpeed = 25;
        [SerializeField] float m_fDegreePerSec = 90;

        //How close the bird will travel to the target before going somewhere else
        [SerializeField] float m_fWanderDistance = 20;

        Vector3 m_v3PositionBeforeRetrieval;
        Quaternion m_RotationBeforeRetrieval;
        EBirdState m_eState = EBirdState.WANDER;
        Vector3 m_v3ArrowPos;
        GameObject m_Camera;
        int m_nTargetIndex;
        // Start is called before the first frame update
        void Start()
        {
            m_RigidBody = GetComponent<Rigidbody>();
            m_Camera = GameObject.FindGameObjectWithTag("MainCamera");

        }

        // Update is called once per frame
        void Update()
        {
            GameObject Arrow = GameObject.FindGameObjectWithTag("MissedArrow");




            List<GameObject> birds = new List<GameObject>(GameObject.FindGameObjectsWithTag("Bird"));
            //If the arrow is not null
            if(Arrow)
            {
                float closestDistance = (birds[0].transform.position - Arrow.transform.position).magnitude;
                for(int i = 1; i < birds.Count; i++)
                {
                    float Dist = (birds[i].transform.position - Arrow.transform.position).magnitude;

                    if(Dist < closestDistance)
                    {
                        closestDistance = Dist;
                    }
                }

                //if you are the closest bird, then set retrieve the arrow
                if(closestDistance == (transform.position - Arrow.transform.position).magnitude)
                {
                    SetArrowToRetrieve(Arrow);
                }
            }

            //State Machine
            switch(m_eState)
            {
                case EBirdState.WANDER:
                    Wander();
                    break;
                case EBirdState.RETRIEVING:
                    Retrieve();
                    break;
                case EBirdState.RETURN:
                    Return();
                    break;
                case EBirdState.RETURNARROW:
                    ReturnArrow();
                    break;
            }
            
            
        }


        void Seek(Vector3 v3SeekTo)
        {
            Vector3 v3Pos = m_RigidBody.transform.position;


            Vector3 DesiredVelocity = (v3SeekTo - v3Pos).normalized * m_fSpeed;
            Vector3 v3Steering = DesiredVelocity - m_RigidBody.velocity;

            m_RigidBody.velocity += v3Steering;

            m_RigidBody.rotation = Quaternion.LookRotation(v3SeekTo, Vector3.up);
        }

        void Return()
        {
            Vector3 v3Pos = m_RigidBody.transform.position;

            if ((v3Pos - m_v3PositionBeforeRetrieval).magnitude < 20)
            {
                SwitchState();
                return;
            }

            Seek(m_v3PositionBeforeRetrieval);
        }

        void ReturnArrow()
        {
            Vector3 v3Pos = m_RigidBody.transform.position;
            Vector3 v3CamPos = m_Camera.transform.position;
            if ((v3Pos - v3CamPos).magnitude < 5)
            {
                GameObject a = GameObject.FindGameObjectWithTag("MissedArrow");
                if(a)
                {
                    a.tag = "Arrow";
                }

                
                SwitchState();
                return;
            }
            Seek(v3CamPos);
        }

        public void SetArrowToRetrieve(GameObject Arrow)
        {
           

            switch(m_eState)
            {
                //If your are wandering, then start retrieving the arrow, switch state
                case EBirdState.WANDER:
                    m_v3ArrowPos = Arrow.transform.position;
                    SwitchState();
                    break;
                //if you are not wandering, then you are either returning, or already retrieving, so do nothing
                default:
                    break;
            }
        }

        //Gets the bird to circle around the m_ToCircle reference
        void Wander()
        {

            List<GameObject> Targets = new List<GameObject>(GameObject.FindGameObjectsWithTag("Target"));

            if(m_nTargetIndex == -1)
            {
                if (Targets.Count != 0)
                {
                    m_nTargetIndex = Random.Range(0, Targets.Count);
                }

            }

            if((Targets[m_nTargetIndex].transform.position - transform.position).magnitude < m_fWanderDistance)
            {
                m_nTargetIndex = -1;
            }


            if(m_nTargetIndex > -1)
            {
                Seek(Targets[m_nTargetIndex].transform.position);
            }


        }

        //Gets the bird to retrieve an arrow
        void Retrieve()
        {
            Vector3 v3Pos = m_RigidBody.transform.position;
            if ((v3Pos - m_v3ArrowPos).magnitude < 5)
            {
                SwitchState();
                return;
            }
            Vector3 DesiredVelocity = (m_v3ArrowPos - v3Pos).normalized * m_fSpeed;
            Vector3 v3Steering = DesiredVelocity - m_RigidBody.velocity;

            m_RigidBody.velocity += v3Steering;

            m_RigidBody.rotation = Quaternion.LookRotation(m_v3ArrowPos,Vector3.up);
        }


        void SwitchState()
        {
            switch(m_eState)
            {
                //If your are wander, then store both rotation and position, then go to the retrieving state
                case EBirdState.WANDER:
                    m_eState = EBirdState.RETRIEVING;
                    m_v3PositionBeforeRetrieval = m_RigidBody.transform.position;
                    m_RotationBeforeRetrieval = m_RigidBody.transform.localRotation;
                    break;
                //If you have returned set rotation back to what it was before then switch state
                case EBirdState.RETURN:
                    m_RigidBody.rotation = m_RotationBeforeRetrieval;
                    m_eState = EBirdState.WANDER;
                    break;
                //If anything else, Nothing needs to be done, just switch state
                case EBirdState.RETRIEVING:
                    m_eState = EBirdState.RETURNARROW;
                    break;
                case EBirdState.RETURNARROW:
                    m_eState = EBirdState.RETURN;
                    break;
               

            }
        }
    }
}