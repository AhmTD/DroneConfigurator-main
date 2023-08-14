using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyColor : MonoBehaviour
{
    public DroneController modelSwitch;
    public GameObject[] drones; // Drone modellerini tutacak dizi
    public Material[] materials;
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
            Renderer droneRenderer = activeDrone.GetComponent<Renderer>();

            if (droneRenderer != null)
            {
                droneRenderer.material = materials[materialIndex];
            }
        }
    }
}
