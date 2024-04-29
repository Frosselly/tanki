using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ScreenBlur : MonoBehaviour
{
    PlayerController playerController;
    DepthOfField depthOfField;

    private bool currentPlayerControllerState;
    DepthOfFieldMode initialMode;
    float initialGaussianStart;
    float initialGaussianEnd;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        currentPlayerControllerState = playerController.enabled;
        
        depthOfField = GetDepthOfField();
        if (depthOfField == null)
        {
            Debug.LogError("Could not find DepthOfField effect", this);
            enabled = false;
            return;
        }
        
        initialMode = depthOfField.mode.value;
        initialGaussianStart = depthOfField.gaussianStart.value;
        initialGaussianEnd = depthOfField.gaussianEnd.value;
    }
    
    private static DepthOfField GetDepthOfField()
    {
        var volume = FindObjectOfType<Volume>();
        if (volume == null)
        {
            Debug.LogError("Could not find Volume");
            return null;
        }
        
        volume.profile.TryGet(out DepthOfField depthOfField);
        return depthOfField;
    }

    bool IsPlayerControllerStateChanged()
    {
        return currentPlayerControllerState != playerController.enabled;
    }
    
    void UpdateCurrentPlayerControllerState()
    {
        currentPlayerControllerState = playerController.enabled;
    }
    
    void UpdateDepthOfField()
    {
        if (playerController.enabled)
        {
            RestoreDepthOfField();
        }
        else
        {
            BlurDepthOfField();
        }
    }
    
    void RestoreDepthOfField()
    {
        depthOfField.mode.value = initialMode;
        depthOfField.gaussianStart.value = initialGaussianStart;
        depthOfField.gaussianEnd.value = initialGaussianEnd;
    }
    
    void BlurDepthOfField()
    {
        depthOfField.mode.value = DepthOfFieldMode.Gaussian;
        depthOfField.gaussianStart.value = 0.0f;
        depthOfField.gaussianEnd.value = 5f;
    }
    
    void Update()
    {
        if (IsPlayerControllerStateChanged())
        {
            UpdateCurrentPlayerControllerState();
            UpdateDepthOfField();
        }
    }
   
}
