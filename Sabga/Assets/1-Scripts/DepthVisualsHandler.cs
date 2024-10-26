using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using Oculus.Interaction;

public class DepthVisualsHandler : MonoBehaviour
{
    // Reference to the URP Asset
    private UniversalRenderPipelineAsset urpAsset;

    void Start()
    {
        // Get the active URP asset (Pipeline settings)
        urpAsset = (UniversalRenderPipelineAsset)GraphicsSettings.currentRenderPipeline;
        var sceneManagerCheck = FindAnyObjectByType<Scene1_Manager>();
        //if(sceneManagerCheck == null)
        //{
        //    DisableFog();
        //}
    }

    // Enable fog
    public void EnableFog()
    {
        if (urpAsset != null)
        {
            urpAsset.supportsCameraDepthTexture = true; // Fog requires depth texture to be enabled
            Shader.EnableKeyword("_FOG_EXP2"); // Enable fog for linear fog mode
            RenderSettings.fog = true;
            Debug.Log("Fog Enabled");
        }
    }

    // Disable fog
    public void DisableFog()
    {
        if (urpAsset != null)
        {
            RenderSettings.fog = false;
            Shader.DisableKeyword("_FOG_LINEAR"); // Disable fog
            Debug.Log("Fog Disabled");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            EnableFog();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            DisableFog();
        }
    }
}