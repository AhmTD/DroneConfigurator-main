using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class GuardSwitchers : MonoBehaviour
{

    public DroneController modelSwitch;
    public Renderer guardRenderer;
    public Material material;


    public Color color;

    [SerializeField]
    private List<GameObject> guardListD0, guardListD1, guardListD2;
    private List<List<GameObject>> guardLists = new List<List<GameObject>>();
    public int currentIndex;
    public Image[] backGround;

    public int droneCurrentIndex;
    private void Start()
    {


        guardLists = new List<List<GameObject>>
{
    guardListD0,
    guardListD1,
    guardListD2
};
        modelSwitch = GameObject.Find("DroneManager").GetComponent<DroneController>();

        ChangeObject(0);
    }
    private void Update()
    {

        droneCurrentIndex = modelSwitch.currentDroneIndex;

    }
    public void ChangeObject(int index)
    {
        // Önceki dronun rengini eski haline getir
        backGround[droneCurrentIndex].color = Color.white;
        // Yeni dronun rengini ayarla
        backGround[index].color = color;
        // Önceki dronun rengini ayarla
        if (index > 0)
        {
            backGround[index - 1].color = Color.white;
        }

        // Sonraki dronun rengini ayarla
        if (index < backGround.Length - 1)
        {
            backGround[index + 1].color = Color.white;
        }
        List<GameObject> guardList = guardLists[droneCurrentIndex];
        for (int i = 0; i < guardList.Count; i++)
        {
            GameObject guard = guardList[i];
            guard.SetActive(i == index);


        }
        guardRenderer = guardList[index].GetComponent<Renderer>();

        ChangeMaterials();

    }

    public void ChangeMaterials()
    {
        // Eðer þu anki materyal birinci materyalse, ikinci materyali ata; aksi halde birinci materyali ata.
        Material newMaterial = material;

        StartCoroutine(ChangeMaterialsCoroutine(newMaterial));
    }

    private System.Collections.IEnumerator ChangeMaterialsCoroutine(Material newMaterial)
    {
        var materialArray = guardRenderer.sharedMaterials;

        // Yeni materyali dronun renderer'ýna atayýn
        materialArray[1] = newMaterial;
        guardRenderer.sharedMaterials = materialArray;
        yield return new WaitForSeconds(2.0f); // 2 saniye bekleyin
        materialArray[1] = null;
        guardRenderer.sharedMaterials = materialArray;
        // Þu anki materyali tekrar dronun renderer'ýna atayýn
    }
}
