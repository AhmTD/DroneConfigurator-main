using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class BackPropellerSwitchers : MonoBehaviour
{
    public DroneController modelSwitch;
    [SerializeField]
    private List<GameObject> backPropellerListD0;
    public Image[] backGround;

    public int droneCurrentIndex;
    private void Start()
    {

        modelSwitch = GameObject.Find("DroneManager").GetComponent<DroneController>();

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
        backGround[index].color = Color.gray;
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
        for (int i = 0; i < backPropellerListD0.Count; i++)
        {
            GameObject propeller = backPropellerListD0[i];
            propeller.SetActive(i == index);
        }
    }

}
