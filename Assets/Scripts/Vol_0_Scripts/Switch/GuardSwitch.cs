using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSwitch : ObjectSwitcher
{

    public ModelSwitch modelSwitch;
    [SerializeField]
    private List<GameObject> guardListD0, guardListD1, guardListD2;
    private List<List<GameObject>> guardLists = new List<List<GameObject>>();
    public int droneCurrentIndex;
    private void Start()
    {
        guardLists = new List<List<GameObject>>
{
    guardListD0,
    guardListD1,
    guardListD2
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
        List<GameObject> guardList = guardLists[droneCurrentIndex];

        for (int i = 0; i < guardList.Count; i++)
        {
            GameObject guard = guardList[i];
            guard.SetActive(i == index);
        }
    }

    public override void ToRightChangerFuncButton()
    {
        List<GameObject> guardList = guardLists[droneCurrentIndex];
        currentIndex++;
        if (currentIndex >= guardList.Count)
        {
            currentIndex = 0;
        }
        ChangeObject(currentIndex);
    }

    public override void ToLeftChangerFuncButton()
    {
        List<GameObject> guardList = guardLists[droneCurrentIndex];
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = guardList.Count - 1;
        }
        ChangeObject(currentIndex);
    }
}