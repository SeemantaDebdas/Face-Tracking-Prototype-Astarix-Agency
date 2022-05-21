using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TabGroup : MonoBehaviour
{
    [SerializeField] Transform itemPanelGroup = null;
    [Header("Sprite")]
    [SerializeField] Sprite activeSprite = null;
    [SerializeField] Sprite inactiveSprite = null;
    [Header("Sprite")]
    [SerializeField] Color activeColor = Color.white;
    [SerializeField] Color inactiveColor = Color.black;

    private void Start()
    {
        ActivateTab(0);
    }

    public void ActivateTab(int i)
    {
        EnablePanel(i);
        foreach (Transform child in transform)
        {
            if(child.GetSiblingIndex() == i)
            {
                SetComponentProperty(child, activeSprite, activeColor, Color.black);
            }
            else
            {
                SetComponentProperty(child, inactiveSprite, inactiveColor, Color.white);
            }

        }
    }

    private void EnablePanel(int i)
    {
        foreach(Transform item in itemPanelGroup)
        {
            if (item.GetSiblingIndex() == i)
            {
                item.gameObject.SetActive(true);
                itemPanelGroup.GetComponent<ScrollRect>().content = item.GetComponent<RectTransform>();
            }
            else
            {
                item.gameObject.SetActive(false);
            }
        }
    }

    private void SetComponentProperty(Transform child, Sprite sprite, Color textColor, Color imageColor)
    {
        child.GetComponent<Image>().sprite = sprite;
        child.GetComponent<Image>().color = imageColor;
        child.GetComponentInChildren<TextMeshProUGUI>().color = textColor;
    }
}
