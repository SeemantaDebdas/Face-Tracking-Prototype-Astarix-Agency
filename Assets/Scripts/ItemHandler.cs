using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class ItemHandler : MonoBehaviour
{
    [SerializeField]
    List<GameObject> itemList;

    ARFaceManager arFaceManager;
    Transform faceManagerClass;
    Transform facePrefabClass;

    private void Awake()
    {
        arFaceManager = GetComponent<ARFaceManager>();
    }

    private void Start()
    {
        ResetAll();
    }

    public void UpdateFace(string classTag, int idx)
    {
        foreach (ARFace face in arFaceManager.trackables)
        {
            foreach (Transform child in face.transform)
            {
                //fetching the class head from hierarchy which matches the tag --> Eyewear, Necklace, Earring, Hat
                if (child.gameObject.CompareTag(classTag))
                    faceManagerClass = child;
            }

            foreach (Transform child in arFaceManager.facePrefab.transform)
            {
                //fetching the class prefab from face prefab
                if (child.gameObject.CompareTag(classTag))
                    facePrefabClass = child;
            }

            //looping through the classListTransform to find the index that matches
            for (int i = 0; i < faceManagerClass.childCount; i++)
            {
                if (i == idx)
                {
                    faceManagerClass.GetChild(i).gameObject.SetActive(true);
                    facePrefabClass.GetChild(i).gameObject.SetActive(true);
                }
                else
                {
                    faceManagerClass.GetChild(i).gameObject.SetActive(false);
                    facePrefabClass.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }

    public void ResetAll()
    {
        foreach (Transform children in arFaceManager.facePrefab.transform)
        {
            if (!children.gameObject.CompareTag("Untagged"))
            {
                for (int i = 0; i < children.childCount; i++)
                {
                    children.GetChild(i).gameObject.SetActive(false);
                }
            }
        }

        foreach (ARFace face in arFaceManager.trackables)
        {
            foreach (Transform child in face.transform)
            {
                if (!child.CompareTag("Untagged"))
                {
                    for (int i = 0; i < child.childCount; i++)
                    {
                        child.GetChild(i).gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    private void OnDisable()
    {
        foreach (Transform children in arFaceManager.facePrefab.transform)
        {
            if (!children.gameObject.CompareTag("Untagged"))
            {
                for (int i = 0; i < children.childCount; i++)
                {
                    children.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }
}