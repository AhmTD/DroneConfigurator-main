using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardColor : MonoBehaviour
{

    public DroneController modelSwitch;
    public List<GameObject> guardListD0, guardListD1, guardListD2;
    private List<List<GameObject>> guardLists = new List<List<GameObject>>();
    public Material[] materials;
    protected int currentMaterialIndex;
    protected int activeDroneIndex;

    void Start()
    {
        guardLists = new List<List<GameObject>>
{
            guardListD0,
            guardListD1,
            guardListD2
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
    public void SetActiveMaterial(int materialIndex)
    {
        List<GameObject> guard = guardLists[activeDroneIndex];
        if (activeDroneIndex >= 0 && activeDroneIndex <= guard.Count)
        {

            for (int i = 0; i < guard.Count; i++)
            {
                Renderer renderer = guard[i].GetComponent<Renderer>();
                renderer.material = materials[materialIndex];
            }


        }
    }








}
