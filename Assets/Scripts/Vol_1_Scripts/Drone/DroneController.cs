using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public GameObject[] closeButton;
    public GameObject guardButton;
    private Vector3 guardStartPos;
    public GameObject[] drones; // Dronlar�n listesi
    public int currentDroneIndex;
    private void Start()
    {
       guardStartPos=guardButton.transform.position;    
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
        currentDroneIndex = index;
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
        if (currentDroneIndex !=0)
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



    public Transform targetPosition; // Hedef pozisyon

    public void MoveToTargetPosition()
    {

        // DOTween ile pozisyonu hedef pozisyona ta��
        guardButton.transform.DOMove(targetPosition.position, 1.0f);
       
    }
}
