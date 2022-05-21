using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class TryWithARButton : MonoBehaviour
{
    Button button;
    string itemTag = "";
    int elementIdx = 0;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(EnableItem);
    }

    public void SetItemValue(string itemTag, int elementTag)
    {
        this.itemTag = itemTag;
        this.elementIdx = elementTag;
    }

    private void EnableItem()
    {
        Debug.Log(itemTag+" "+elementIdx);
        FindObjectOfType<ARSessionOrigin>().GetComponent<ItemHandler>().UpdateFace(itemTag, elementIdx);
    }

}
