using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerColor : MonoBehaviour
{

    public DroneController modelSwitch;
    public List<GameObject> propellerListD0, propellerListD1, propellerListD2;
    private List<List<GameObject>> propellerLists = new List<List<GameObject>>();
    public Material[] materials;
    protected int currentMaterialIndex;
    protected int activeDroneIndex;

    void Start()
    {
        propellerLists = new List<List<GameObject>>
{
            propellerListD0,
            propellerListD1,
            propellerListD2
};
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
    public  void SetActiveMaterial(int materialIndex)
    {
        List<GameObject> propeller = propellerLists[activeDroneIndex];
        if (activeDroneIndex >= 0 && activeDroneIndex <= propeller.Count)
        {

            for (int i = 0; i < propeller.Count; i++)
            {
                Renderer renderer = propeller[i].GetComponent<Renderer>();
                renderer.material = materials[materialIndex];
            }


        }
    }
}
