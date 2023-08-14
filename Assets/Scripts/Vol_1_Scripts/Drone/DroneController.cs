using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public GameObject[] closeButton;
    public GameObject guardButton;
    private Vector3 guardStartPos;
    public GameObject[] drones; // Dronlarýn listesi
    public int currentDroneIndex;
    private void Start()
    {
       guardStartPos=guardButton.transform.position;    
    }
    // Dronlarý devre dýþý býrakýr
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

    // Belirli bir dronu etkinleþtirir
    public void ActivateDrone(int index)
    {
        currentDroneIndex = index;
        // Önce tüm dronlarý devre dýþý býrakýn
        DeactivateAllDrones();

        // Belirli indeksteki dronu etkinleþtirin
        if (index >= 0 && index < drones.Length)
        {
            drones[index].SetActive(true);
        }
    }

    public void ButtonController()
    {
        if (currentDroneIndex !=0)
        {
            // Butonlarý yavaþça kaybolmasý için loop animasyonu uygula
            for (int i = 0; i < closeButton.Length; i++)
            {
                closeButton[i].transform.DOScale(Vector3.zero, 0.5f) // Bu satýr, butonun boyutunu sýfýra yavaþça deðiþtirecek
                    .OnComplete(() => closeButton[i].SetActive(false)); // Bu satýr, boyut sýfýra ulaþtýðýnda butonu devre dýþý býrakacak
            }
            guardButton.transform.DOMove(targetPosition.position, 1.0f);
        }
        else
        {
            // Butonlarý yavaþça göstermek için loop animasyonu uygula
            for (int i = 0; i < closeButton.Length; i++)
            {
                closeButton[i].SetActive(true); // Önce butonu aktifleþtir
                closeButton[i].transform.DOScale(Vector3.one, 0.5f); // Bu satýr, butonun boyutunu bir'e yavaþça deðiþtirecek
                guardButton.transform.DOMove(guardStartPos, 1.0f);
            }
        }
    }



    public Transform targetPosition; // Hedef pozisyon

    public void MoveToTargetPosition()
    {

        // DOTween ile pozisyonu hedef pozisyona taþý
        guardButton.transform.DOMove(targetPosition.position, 1.0f);
       
    }
}
