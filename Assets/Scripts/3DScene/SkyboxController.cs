using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    public Texture[] skyboxTextures; // Array to hold the HDR skybox textures
    public Material skyboxMaterial;  // Reference to the skybox material
    public Camera targetCamera;      // Reference to the camera
    public GameObject SceneCanvas;
    public GameObject SkyboxCanvas;
    public GameObject ObjectSceneViews;

    //Start Function 
    private void Start()
    {
      
    }
    // Method to change the skybox texture at the specified index
    public void ChangeSkyboxTexture(int index)
    {
        if (index >= 0 && index < skyboxTextures.Length)
        {
            skyboxMaterial.SetTexture("_MainTex", skyboxTextures[index]);
            RenderSettings.skybox = skyboxMaterial;
            DynamicGI.UpdateEnvironment(); // Update the environment to reflect the change

            // Change camera environment setting to skybox
            if (targetCamera != null)
            {
                targetCamera.clearFlags = CameraClearFlags.Skybox;
            }

            SceneCanvas.SetActive(false);
            SkyboxCanvas.SetActive(true);
            ObjectSceneViews.SetActive(false);
        }

        else
        {
            Debug.LogError("Invalid index: " + index);
        }
    }
    public void SetSkyboxToSolidColor()
    {
        targetCamera.clearFlags = CameraClearFlags.SolidColor;
    }
}
