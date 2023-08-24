using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class PropellerSwitchs : MonoBehaviour
{
    // Ba�ka bir DroneController bile�enine referans sa�lar.
    public DroneController modelSwitch;
    // Farkl� pervane gruplar�n� i�eren listeler.
    [SerializeField] private List<GameObject> propellersListD0, propellersListD1, propellersListD2;
    // T�m pervane gruplar�n� i�eren ana liste.
    private List<List<GameObject>> propellersLists = new List<List<GameObject>>();
    // Mevcut pervane grubunun indeksini belirtir.
    public int currentIndex;
    // Arka plan g�r�nt�lerini i�eren dizi.
    public Image[] backGround;
    // Arka plan rengini belirlemek i�in kullan�l�r.
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
        // �nceki dronun rengini eski haline getir
        backGround[currentIndex].color = Color.white;
        // Yeni dronun rengini ayarla
        backGround[index].color = color;

        currentIndex = index;
        // �nceki dronun rengini ayarla
        if (currentIndex > 0)
        {
            backGround[currentIndex - 1].color = Color.white;
        }

        // Sonraki dronun rengini ayarla
        if (currentIndex < backGround.Length - 1)
        {
            backGround[currentIndex + 1].color = Color.white;
        }
        #endregion


        //Propeller de�i�tirmeye yarayan k�s�m
        List<GameObject> propellersList = propellersLists[droneCurrentIndex];

        for (int i = 0; i < propellersList.Count; i++)
        {
            GameObject propeller = propellersList[i];
            propeller.SetActive(i == index);
        }
    }



}
