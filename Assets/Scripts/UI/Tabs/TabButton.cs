using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabButton : MonoBehaviour
{
    TabGroup tabGroup;
    Button button;

    private void Awake()
    {
        tabGroup = GetComponentInParent<TabGroup>();
        button = GetComponentInParent<Button>();

        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        tabGroup.ActivateTab(transform.GetSiblingIndex());
    }
}
