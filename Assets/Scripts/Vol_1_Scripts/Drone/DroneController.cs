using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneController : MonoBehaviour
{
    [Header("DroneButton")]
    public GameObject[] closeButton;
    public GameObject guardButton;
    private Vector3 guardStartPos;
    public GameObject[] drones; // Dronlar�n listesi
    public int currentDroneIndex;
    public Transform targetPosition; // Hedef pozisyon

    public Image[] backGround;



    private void Start()
    {
        guardStartPos = guardButton.transform.position;
    }
    // Dronlar� devre d��� b�rak�r
    private void Update()
    {
        ButtonController();
    }
    private void DeactivateAllDrones()
    {
        foreach (GameObject drone in drones)
        {
            drone.SetActive(false);
        }
    }

    // Belirli bir dronu etkinle�tirir
    public void ActivateDrone(int index)
    {
     
        // �nceki dronun rengini eski haline getir
        backGround[currentDroneIndex].color = Color.white;

        // Yeni dronun rengini ayarla
        backGround[index].color = Color.gray;

        // currentDroneIndex'i g�ncelle
        currentDroneIndex = index;

        // �nceki dronun rengini ayarla
        if (currentDroneIndex > 0)
        {
            backGround[currentDroneIndex - 1].color = Color.white;
        }

        // Sonraki dronun rengini ayarla
        if (currentDroneIndex < backGround.Length - 1)
        {
            backGround[currentDroneIndex + 1].color = Color.white;
        }



        // �nce t�m dronlar� devre d��� b�rak�n
        DeactivateAllDrones();

        // Belirli indeksteki dronu etkinle�tirin
        if (index >= 0 && index < drones.Length)
        {
            drones[index].SetActive(true);
        }
    }

    public void ButtonController()
    {
        if (currentDroneIndex != 0)
        {
            // Butonlar� yava��a kaybolmas� i�in loop animasyonu uygula
            for (int i = 0; i < closeButton.Length; i++)
            {
                closeButton[i].transform.DOScale(Vector3.zero, 0.5f) // Bu sat�r, butonun boyutunu s�f�ra yava��a de�i�tirecek
                    .OnComplete(() => closeButton[i].SetActive(false)); // Bu sat�r, boyut s�f�ra ula�t���nda butonu devre d��� b�rakacak
            }
            guardButton.transform.DOMove(targetPosition.position, 1.0f);
        }
        else
        {
            // Butonlar� yava��a g�stermek i�in loop animasyonu uygula
            for (int i = 0; i < closeButton.Length; i++)
            {
                closeButton[i].SetActive(true); // �nce butonu aktifle�tir
                closeButton[i].transform.DOScale(Vector3.one, 0.5f); // Bu sat�r, butonun boyutunu bir'e yava��a de�i�tirecek
                guardButton.transform.DOMove(guardStartPos, 1.0f);
            }
        }
    }

    public void MoveToTargetPosition()
    {

        // DOTween ile pozisyonu hedef pozisyona ta��
        guardButton.transform.DOMove(targetPosition.position, 1.0f);

    }
}
