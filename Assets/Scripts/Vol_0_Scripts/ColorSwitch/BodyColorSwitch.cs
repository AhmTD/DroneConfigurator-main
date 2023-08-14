using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class BodyColorSwitch : ColorSwitcher
{
    public ModelSwitch modelSwitch;
    public GameObject[] drones; // Drone modellerini tutacak dizi


    void Start()
    {
        modelSwitch = GameObject.Find("ModelManager").GetComponent<ModelSwitch>();
      
    }

    private void Update()
    {
       
        activeDroneIndex =modelSwitch.currentDroneIndex;
      
    }
    // Drone materyallerini deðiþtirecek olan düðme için çaðýrýlacak metot
    public override void ChangeMaterial()
    {
        currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;
        SetActiveMaterial(currentMaterialIndex);

    }

    // Aktif dronenun materyalini deðiþtirecek olan metot
    public override void SetActiveMaterial(int materialIndex)
    {
        if (activeDroneIndex >= 0 && activeDroneIndex < drones.Length)
        {
            GameObject activeDrone = drones[activeDroneIndex];
            Renderer droneRenderer = activeDrone.GetComponent<Renderer>();

            if (droneRenderer != null)
            {
                droneRenderer.material = materials[materialIndex];
            }
            //#region
            //Material[] material = droneRenderer.materials;
            //if (droneRenderer != null)
            //{
            //    for (int i = 0; i < droneRenderer.materials.Length; i++)
            //    {
            //        Debug.Log(material[i].name);

            //        material[1] = materials[materialIndex];
            //    }

            //}
            //#endregion

        }
    }

    // Aktif olan droneyý bulacak olan metot
 
}

