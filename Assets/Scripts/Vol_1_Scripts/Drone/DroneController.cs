using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneController : MonoBehaviour
{
    public Renderer droneRenderer;
    public Material material;
    public GameObject[] bodyMesh;

    [Header("DroneButton")]
    public GameObject[] closeButton;
    public GameObject guardButton;
    private Vector3 guardStartPos;
    public GameObject[] drones; // Dronlar�n listesi
    public int currentDroneIndex;
    public Transform targetPosition; // Hedef pozisyon
    public Color color;

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
        backGround[index].color = color;
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
        droneRenderer = bodyMesh[index].GetComponent<Renderer>();
        ChangeMaterials();
    }

    public void ChangeMaterials()
    {
        // E�er �u anki materyal birinci materyalse, ikinci materyali ata; aksi halde birinci materyali ata.
        Material newMaterial = material;

        StartCoroutine(ChangeMaterialsCoroutine(newMaterial));
    }

    private System.Collections.IEnumerator ChangeMaterialsCoroutine(Material newMaterial)
    {
        var materialArray = droneRenderer.sharedMaterials;

        // Yeni materyali dronun renderer'�na atay�n
        materialArray[1] = newMaterial;
        droneRenderer.sharedMaterials = materialArray;
        yield return new WaitForSeconds(2.0f); // 2 saniye bekleyin
        materialArray[1] = null;
        droneRenderer.sharedMaterials = materialArray;


        // �u anki materyali tekrar dronun renderer'�na atay�n
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
