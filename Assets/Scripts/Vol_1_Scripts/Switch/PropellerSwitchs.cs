using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class PropellerSwitchs : MonoBehaviour
{
    public DroneController modelSwitch;
    [SerializeField]
    private List<GameObject> propellersListD0, propellersListD1, propellersListD2;
    private List<List<GameObject>> propellersLists = new List<List<GameObject>>();
    public int currentIndex;
    public Image[] backGround;

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

    }
    private void Update()
    {

        droneCurrentIndex = modelSwitch.currentDroneIndex;
       
    }
    public  void ChangeObject(int index)
    {

        #region BackGroundColorChance
        // Önceki dronun rengini eski haline getir
        backGround[droneCurrentIndex].color= Color.white;
        // Yeni dronun rengini ayarla
        backGround[index].color = Color.gray;
        // Önceki dronun rengini ayarla
        if (index > 0)
        {
            backGround[index - 1].color = Color.white;
        }

        // Sonraki dronun rengini ayarla
        if (index < backGround.Length-1)
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
    }

}
