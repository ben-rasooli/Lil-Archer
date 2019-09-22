
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
        Button m_Button;

    // Start is called before the first frame update
    void Start()
        {
            m_Button = GetComponent<Button>();
            m_Button.onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            //Edited by Jack
            //Completely reloads scene as opposed to simply reseting the score
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
