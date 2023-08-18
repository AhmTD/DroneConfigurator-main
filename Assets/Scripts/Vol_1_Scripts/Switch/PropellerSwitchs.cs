using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class PropellerSwitchs : MonoBehaviour
{
    public DroneController modelSwitch;
    public GameObject[] meshPropeller;
    public Renderer propellerRenderer;
    public Material material;
    [SerializeField]
    private List<GameObject> propellersListD0, propellersListD1, propellersListD2;
    private List<List<GameObject>> propellersLists = new List<List<GameObject>>();
    public int currentIndex;
    public Image[] backGround;
    public Color color;

    public int droneCurrentIndex;
    private void Start()
    {
        propellersLists = new List<List<GameObject>>
{
    propellersListD0,
    propellersListD1,
    propellersListD2
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

        #region BackGroundColorChance
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
        #endregion


        //Propeller deðiþtirmeye yarayan kýsým
        List<GameObject> propellersList = propellersLists[droneCurrentIndex];

        for (int i = 0; i < propellersList.Count; i++)
        {
            GameObject propeller = propellersList[i];
            propeller.SetActive(i == index);
        }
        for (int i = 0; i < meshPropeller.Length; i++)
        {
            propellerRenderer = meshPropeller[i].GetComponent<Renderer>();
            ChangeMaterials();
        }

    }
    public void ChangeMaterials()
    {
        // Eðer þu anki materyal birinci materyalse, ikinci materyali ata; aksi halde birinci materyali ata.
        Material newMaterial = material;

        StartCoroutine(ChangeMaterialsCoroutine(newMaterial));
    }

    private System.Collections.IEnumerator ChangeMaterialsCoroutine(Material newMaterial)
    {
        var materialArray = propellerRenderer.sharedMaterials;
        // Yeni materyali dronun renderer'ýna atayýn
        materialArray[1] = newMaterial;
        propellerRenderer.sharedMaterials = materialArray;
        yield return new WaitForSeconds(2.0f); // 2 saniye bekleyin
        materialArray[1] = null;
        propellerRenderer.sharedMaterials = materialArray;
        // Þu anki materyali tekrar dronun renderer'ýna atayýn
    }


}
