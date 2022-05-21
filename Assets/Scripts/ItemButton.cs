using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ItemButton : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] string itemTag;
    [SerializeField] int elementIndex;
    Button button;
    Item3DViewer item3DViewer;
    TryWithARButton arButton;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        item3DViewer = FindObjectOfType<Item3DViewer>();
        button.onClick.AddListener(ActivateItem);
    }

    private void ActivateItem()
    {
        item3DViewer.SpawnObject(obj);
        FindObjectOfType<TryWithARButton>().SetItemValue(itemTag, elementIndex);
    }
}
