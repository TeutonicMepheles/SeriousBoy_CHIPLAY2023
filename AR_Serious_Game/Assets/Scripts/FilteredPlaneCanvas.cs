using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilteredPlaneCanvas : MonoBehaviour
{
    [SerializeField] private Toggle verticalPlaneToggle;
    [SerializeField] private Toggle horizontalPlaneToggle;
    [SerializeField] private Toggle bigPlaneToggle;
    [SerializeField] private Button startButton;

    private ARFilteredPlanes _arFilteredPlanes;

    public bool VerticalPlaneToggle
    {
        get => verticalPlaneToggle.isOn;
        set
        {
            verticalPlaneToggle.isOn = value;
            checkIfAllAreTrue();
        }
    }
    
    public bool HorizontalPlaneToggle
    {
        get => horizontalPlaneToggle.isOn;
        set
        {
            horizontalPlaneToggle.isOn = value;
            checkIfAllAreTrue();
        }
    }

    public bool BigPlaneToggle 
    {
        get => bigPlaneToggle.isOn;
        set
        {
            bigPlaneToggle.isOn = value;
            checkIfAllAreTrue();
        }
    }
    private void checkIfAllAreTrue()
    {
        if (VerticalPlaneToggle && HorizontalPlaneToggle && BigPlaneToggle)
        {
            startButton.interactable = true;
        }
    }

    private void OnEnable()
    {
        _arFilteredPlanes = FindObjectOfType<ARFilteredPlanes>();
        _arFilteredPlanes.OnVerticalPlaneFounded += () => VerticalPlaneToggle = true;
        _arFilteredPlanes.OnHorizontalPlaneFounded += () => HorizontalPlaneToggle = true;
        _arFilteredPlanes.OnBigPlaneFounded += () => BigPlaneToggle = true;
        
    }

    private void OnDisable()
    {
        _arFilteredPlanes.OnVerticalPlaneFounded -= () => VerticalPlaneToggle = true;
        _arFilteredPlanes.OnHorizontalPlaneFounded -= () => HorizontalPlaneToggle = true;
        _arFilteredPlanes.OnBigPlaneFounded -= () => BigPlaneToggle = true; 
    }
}
