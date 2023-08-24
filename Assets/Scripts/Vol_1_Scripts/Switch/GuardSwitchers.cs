using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class GuardSwitchers : MonoBehaviour
{

    public DroneController modelSwitch;
    [SerializeField]
    private List<GameObject> guardListD0, guardListD1, guardListD2;
    private List<List<GameObject>> guardLists = new List<List<GameObject>>();
    public int currentIndex;
    public int droneCurrentIndex;

    public Color color;
    public Image[] backGround;

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
        backGround[currentIndex].color = Color.white;
        // Yeni dronun rengini ayarla
        backGround[index].color = color;

        currentIndex = index;
        // Önceki dronun rengini ayarla
        if (currentIndex > 0)
        {
            backGround[currentIndex - 1].color = Color.white;
        }

        // Sonraki dronun rengini ayarla
        if (currentIndex < backGround.Length - 1)
        {
            backGround[currentIndex + 1].color = Color.white;
        }
        List<GameObject> guardList = guardLists[droneCurrentIndex];
        for (int i = 0; i < guardList.Count; i++)
        {
            GameObject guard = guardList[i];
            guard.SetActive(i == index);


        }

    }


}
