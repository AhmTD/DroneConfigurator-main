using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneRotation : MonoBehaviour
{
    public float rotationSpeed = 10f; // Yava� d�nme h�z�
    public float mouseRotationSpeed = 100f; // Mouse ile d�nme h�z�

    private Vector3 lastMousePosition; // Son mouse konumu

    private bool isViewLocked = false; // Kilitli g�r�n�m durumu

    public Transform rotationPoint; // D�nme noktas�

    public Button lockButton; // LockView butonu
    public Button unlockButton; // UnlockView butonu

    

    void Start()
    {
        // Ba�lang��ta unlockButton aktif, lockButton deaktif olacak
        lockButton.gameObject.SetActive(true);
        unlockButton.gameObject.SetActive(false);
    }

    void Update()
    {
        RotationFunc();
    }

    void RotationFunc()
    {
        // Yava� d�nme
        if (!isViewLocked)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        // Nesnenin belirlenen nokta etraf�nda d�nmesi
        if (rotationPoint != null && !isViewLocked)
        {
            float angle = rotationSpeed * Time.deltaTime;
            transform.RotateAround(rotationPoint.position, Vector3.up, angle);
        }
    }

    // LockView fonksiyonu, drone'un kendi kendine d�nmeyi durdurur ve sadece mouse ile d�nd�rmeyi aktifle�tirir
    public void LockView()
    {
        isViewLocked = true;

        // LockView butonunu deaktif et
        lockButton.gameObject.SetActive(false);

        // UnlockView butonunu aktif et
        unlockButton.gameObject.SetActive(true);

        // "DroneParent" tag'ine sahip t�m nesnelerde d�nmeyi durdur
        GameObject[] droneParents = GameObject.FindGameObjectsWithTag("DroneParent");
        foreach (GameObject droneParent in droneParents)
        {
            DroneRotation droneRotation = droneParent.GetComponent<DroneRotation>();
            if (droneRotation != null)
            {
                droneRotation.isViewLocked = true;
            }
        }
    }

    // UnlockView fonksiyonu, drone'un kendi kendine d�nmeye devam etmesini sa�lar ve mouse ile d�nd�rmeyi aktifle�tirir
    public void UnlockView()
    {
        isViewLocked = false;

        // UnlockView butonunu deaktif et
        unlockButton.gameObject.SetActive(false);

        // LockView butonunu aktif et
        lockButton.gameObject.SetActive(true);

        // "DroneParent" tag'ine sahip t�m nesnelerde d�nmeyi aktifle�tir
        GameObject[] droneParents = GameObject.FindGameObjectsWithTag("DroneParent");
        foreach (GameObject droneParent in droneParents)
        {
            DroneRotation droneRotation = droneParent.GetComponent<DroneRotation>();
            if (droneRotation != null)
            {
                droneRotation.isViewLocked = false;
            }
        }
    }
}
