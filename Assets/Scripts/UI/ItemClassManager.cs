using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemClassManager : MonoBehaviour
{
    [SerializeField] GameObject[] panels;
    SideMenuButton sideMenuButton;
    Button button;
    private void Awake()
    {
        button= GetComponent<Button>();
        button.onClick.AddListener(ActivateClass);
    }

    private void Start()
    {
        sideMenuButton = FindObjectOfType<SideMenuButton>();
    }

    private void ActivateClass()
    {
        for(int i= 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == transform.GetSiblingIndex());
        }
        //sideMenuButton.ToggleState(true);
    }

}
