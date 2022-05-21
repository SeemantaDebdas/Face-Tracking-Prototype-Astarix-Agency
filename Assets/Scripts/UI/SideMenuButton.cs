using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideMenuButton : MonoBehaviour
{
    [SerializeField] Animator anim;
    Toggle toggle;

    private void Awake()
    {
        anim.SetBool("Hide", false);

        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(ToggleState);
    }

    public void ToggleState(bool state)
    {
        Debug.Log("Called");
        anim.SetBool("Hide", state);
    }
}
