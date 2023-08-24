using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyColor : MonoBehaviour
{
    public DroneController modelSwitch;
    public Renderer droneRenderer;
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
    // Drone materyallerini deðiþtirecek olan düðme için çaðýrýlacak metot
    public void ChangeMaterial()
    {
        currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;
        SetActiveMaterial(currentMaterialIndex);

    }

    // Aktif dronenun materyalini deðiþtirecek olan metot
    public void SetActiveMaterial(int materialIndex)
    {
        if (activeDroneIndex >= 0 && activeDroneIndex < drones.Length)
        {
            GameObject activeDrone = drones[activeDroneIndex];
            droneRenderer = activeDrone.GetComponent<Renderer>();

            if (droneRenderer != null)
            {
                var materialArray = droneRenderer.sharedMaterials;
                materialArray[0] = materials[materialIndex];
                materialArray[1] = materials[materialIndex];
                droneRenderer.sharedMaterials = materialArray;
                backGround.DOColor(colors[materialIndex], transitionDuration);
                  
             

            }
        }
    }
}
