using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPropellerColor : MonoBehaviour
{
    public DroneController modelSwitch;
    public List<GameObject> propellerListD0;
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
       
        if (activeDroneIndex >= 0 && activeDroneIndex <= propellerListD0.Count)
        {

            for (int i = 0; i < propellerListD0.Count; i++)
            {
                Renderer renderer = propellerListD0[i].GetComponent<Renderer>();
                renderer.material = materials[materialIndex];
            }


        }
    }





}
