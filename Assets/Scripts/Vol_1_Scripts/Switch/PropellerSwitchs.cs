using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerSwitchs : MonoBehaviour
{
    public DroneController modelSwitch;
    [SerializeField]
    private List<GameObject> propellersListD0, propellersListD1, propellersListD2;
    private List<List<GameObject>> propellersLists = new List<List<GameObject>>();
    public int currentIndex;

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
        currentIndex = 0;
        ChangeObject(currentIndex);
    }
    private void Update()
    {

        droneCurrentIndex = modelSwitch.currentDroneIndex;
       
    }
    public  void ChangeObject(int index)
    {
        List<GameObject> propellersList = propellersLists[droneCurrentIndex];

        for (int i = 0; i < propellersList.Count; i++)
        {
            GameObject propeller = propellersList[i];
            propeller.SetActive(i == index);
        }
    }

}
