using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    [SerializeField] Button m_button;
    [SerializeField] GameObject m_ControlMenu;
    [SerializeField] GameObject m_PauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        m_button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        m_PauseMenu.SetActive(false);
        m_ControlMenu.SetActive(true);

    }
}
