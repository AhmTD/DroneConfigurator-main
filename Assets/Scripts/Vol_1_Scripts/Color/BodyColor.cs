using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;

public class BodyColor : MonoBehaviour
{
    public DroneController modelSwitch;
    public GameObject[] drones; // Drone modellerini tutacak dizi
    public Material[] materials;
    public Color[] colors;
    public Image backGround;
    public float transitionDuration = 1.0f;
    protected int currentMaterialIndex;
    protected int activeDroneIndex;


    void Start()
    {
        modelSwitch = GameObject.Find("DroneManager").GetComponent<DroneController>();

    }

    private void Update()
    {

        activeDroneIndex = modelSwitch.currentDroneIndex;

    }
    // Drone materyallerini de�i�tirecek olan d��me i�in �a��r�lacak metot
    public void ChangeMaterial()
    {
        currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;
        SetActiveMaterial(currentMaterialIndex);

    }

    // Aktif dronenun materyalini de�i�tirecek olan metot
    public void SetActiveMaterial(int materialIndex)
    {
        if (activeDroneIndex >= 0 && activeDroneIndex < drones.Length)
        {
            GameObject activeDrone = drones[activeDroneIndex];
            Renderer droneRenderer = activeDrone.GetComponent<Renderer>();

            if (droneRenderer != null)
            {
                droneRenderer.material = materials[materialIndex];
                backGround.DOColor(colors[materialIndex], transitionDuration);
                  
             

            }
        }
    }
}
