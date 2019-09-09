using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.XR;

namespace Project
{
    public class OnStartUp : MonoBehaviour
    {
        public GameObject m_CameraPrefab;
        public GameObject m_VrCameraRig;
        private void Awake()
        {

            //if(EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android)
            //{
            //    var myCamera = Instantiate(m_CameraPrefab);
            //    myCamera.transform.position = m_CameraPosition;
            //}
            //else if(EditorUserBuildSettings.activeBuildTarget == BuildTarget.StandaloneWindows)
            //{
            //    var myCamera = Instantiate(m_VrCameraRig);
            //    myCamera.transform.position = m_CameraPosition;
            //}

#if UNITY_ANDROID
            XRSettings.enabled = false;
            m_CameraPrefab.SetActive(true);
            GetComponent<TabletInput>().enabled = true;
#elif UNITY_STANDALONE_WIN
        XRSettings.enabled = true;
        m_VrCameraRig.SetActive(true);
        GetComponent<VRInput>().enabled = true;
#endif
        }


        // Update is called once per frame
        void Update()
        {

        }
    }
}
