using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSwitchers : MonoBehaviour
{
    public DroneController modelSwitch;
    [SerializeField]
    private List<GameObject> guardListD0, guardListD1, guardListD2;
    private List<List<GameObject>> guardLists = new List<List<GameObject>>();
    public int currentIndex;

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
        currentIndex = 0;
        ChangeObject(currentIndex);
    }
    private void Update()
    {

        droneCurrentIndex = modelSwitch.currentDroneIndex;

    }
    public void ChangeObject(int index)
    {
        List<GameObject> guardList = guardLists[droneCurrentIndex];

        for (int i = 0; i < guardList.Count; i++)
        {
            GameObject propeller = guardList[i];
            propeller.SetActive(i == index);
        }
    }
}
