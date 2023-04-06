using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARPlaneManager))]
[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARAnchorManager))]
public class ARAnchorManagerNew : MonoBehaviour
{

    private ARPlaneManager _arPlaneManager;

    private ARRaycastManager _arRaycastManager;

    private ARAnchorManager _arAnchorManager;

    private List<ARAnchor> _anchors = new List<ARAnchor>();

    private static List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    
    // Start is called before the first frame update
    void Awake()
    {
        _arPlaneManager = GetComponent<ARPlaneManager>();
        _arRaycastManager = GetComponent<ARRaycastManager>();
        _arAnchorManager = GetComponent<ARAnchorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;
        Touch touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
            return;
        if (_arRaycastManager.Raycast(touch.position,_hits,TrackableType.PlaneWithinPolygon))
        {
            Pose pose = _hits[0].pose;
            ARAnchor anchor = _arAnchorManager.AddAnchor(pose);
            if (anchor == null)
            {
                string errorEntry = "There is an error creating an anchor\n";
                Debug.Log(errorEntry);
            }
            else
            {
                _anchors.Add(anchor);
            }
        }
    }

    
}
