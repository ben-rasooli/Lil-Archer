﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Added by Jack
using UnityEngine.SceneManagement;

namespace Project
{
    public class ResetButton : MonoBehaviour
    {
        StatsManager m_StatsManager;
        Button m_Button;

    // Start is called before the first frame update
    void Start()
        {
            m_StatsManager = FindObjectOfType<StatsManager>();
            m_Button = GetComponent<Button>();
            m_Button.onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            m_StatsManager.Reset();

            //Added by Jack
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
