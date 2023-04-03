using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARFilteredPlanes : MonoBehaviour
{
    public event Action OnVerticalPlaneFounded;
    public event Action OnHorizontalPlaneFounded;
    public event Action OnBigPlaneFounded;
    
    [SerializeField] private Vector2 dimensionsForBigPlane;
    private ARPlaneManager _arPlaneManager;
    private List<ARPlane> _arPlanes;

    private void OnEnable()
    {
        _arPlanes = new List<ARPlane>();
        _arPlaneManager = FindObjectOfType<ARPlaneManager>();
        _arPlaneManager.planesChanged += OnPlanesChanged;
    }

    private void OnDisable()
    {
        _arPlaneManager.planesChanged -= OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        // 首先确保有一个args
        if (args.added != null && args.added.Count > 0)
        {
            _arPlanes.AddRange(args.added);
        }

        foreach (ARPlane plane in _arPlanes.Where(plane => plane.extents.x*plane.extents.y>=0.1f))
        {
            
            if (plane.alignment.IsVertical())
            {
                // 确认找到垂直的ARplane
                OnVerticalPlaneFounded.Invoke();
            }
            else
            {
                // 确认找到平行的ARplane
                OnHorizontalPlaneFounded.Invoke();
            }

            if (plane.extents.x * plane.extents.y >= dimensionsForBigPlane.x * dimensionsForBigPlane.y)
            {
                // 确认找到一个大的平面
                OnBigPlaneFounded.Invoke();
            }
        }
    }
}
