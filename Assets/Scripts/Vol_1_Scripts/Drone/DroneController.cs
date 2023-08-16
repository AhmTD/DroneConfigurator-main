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
    public GameObject[] drones; // Dronlarýn listesi
    public int currentDroneIndex;
    public Transform targetPosition; // Hedef pozisyon

    public Image[] backGround;



    private void Start()
    {
        guardStartPos = guardButton.transform.position;
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
     
        // Önceki dronun rengini eski haline getir
        backGround[currentDroneIndex].color = Color.white;

        // Yeni dronun rengini ayarla
        backGround[index].color = Color.gray;

        // currentDroneIndex'i güncelle
        currentDroneIndex = index;

        // Önceki dronun rengini ayarla
        if (currentDroneIndex > 0)
        {
            backGround[currentDroneIndex - 1].color = Color.white;
        }

        // Sonraki dronun rengini ayarla
        if (currentDroneIndex < backGround.Length - 1)
        {
            backGround[currentDroneIndex + 1].color = Color.white;
        }



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
        if (currentDroneIndex != 0)
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

    public void MoveToTargetPosition()
    {

        // DOTween ile pozisyonu hedef pozisyona taþý
        guardButton.transform.DOMove(targetPosition.position, 1.0f);

    }
}
