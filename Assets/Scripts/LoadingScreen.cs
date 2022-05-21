using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class LoadingScreen : MonoBehaviour
{
    ARFaceManager faceManager;
    [SerializeField] GameObject mainCanvas;
    bool faceDetectedDuringStart = false;

    private void OnEnable()
    {
        faceManager = FindObjectOfType<ARFaceManager>();
        faceManager.facesChanged += FacesChanged;
    }

    private void FacesChanged(ARFacesChangedEventArgs faceEvent)
    {
        if (faceEvent.added.Count > 0 && !faceDetectedDuringStart)
        {
            faceDetectedDuringStart = true;
            DeactivateLoadScreen();
        }
    }

    void DeactivateLoadScreen()
    {
        mainCanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        faceManager.facesChanged -= FacesChanged;
    }
}
