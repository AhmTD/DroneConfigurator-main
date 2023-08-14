using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PropellerSwitch : ObjectSwitcher
{
    public ModelSwitch modelSwitch;
    [SerializeField]
    private List<GameObject> propellersListD0, propellersListD1, propellersListD2;
    private List<List<GameObject>> propellersLists = new List<List<GameObject>>();


    public int droneCurrentIndex;
    private void Start()
    {
        propellersLists = new List<List<GameObject>>
{
    propellersListD0,
    propellersListD1,
    propellersListD2
};
        modelSwitch = GameObject.Find("ModelManager").GetComponent<ModelSwitch>();
        currentIndex = 0;
        ChangeObject(currentIndex);
    }
    private void Update()
    {
       
        droneCurrentIndex = modelSwitch.currentDroneIndex;
    }
    public override void ChangeObject(int index)
    {
        List<GameObject> propellersList = propellersLists[droneCurrentIndex];

        for (int i = 0; i < propellersList.Count; i++)
        {
            GameObject propeller = propellersList[i];
            propeller.SetActive(i == index);
        }
    }

    public override void ToRightChangerFuncButton()
    {
        List<GameObject> propellersList = propellersLists[droneCurrentIndex];
        currentIndex++;
        if (currentIndex >= propellersList.Count)
        {
            currentIndex = 0;
        }
        ChangeObject(currentIndex);
    }

    public override void ToLeftChangerFuncButton()
    {
        List<GameObject> propellersList = propellersLists[droneCurrentIndex];
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = propellersList.Count-1;
        }
        ChangeObject(currentIndex);
    }
}
