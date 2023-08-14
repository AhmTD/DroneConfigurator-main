using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneRotation : MonoBehaviour
{
    public float rotationSpeed = 10f; // Yavaþ dönme hýzý
    public float mouseRotationSpeed = 100f; // Mouse ile dönme hýzý

    private Vector3 lastMousePosition; // Son mouse konumu

    private bool isViewLocked = false; // Kilitli görünüm durumu

    public Transform rotationPoint; // Dönme noktasý

    public Button lockButton; // LockView butonu
    public Button unlockButton; // UnlockView butonu

    

    void Start()
    {
        // Baþlangýçta unlockButton aktif, lockButton deaktif olacak
        lockButton.gameObject.SetActive(true);
        unlockButton.gameObject.SetActive(false);
    }

    void Update()
    {
        RotationFunc();
    }

    void RotationFunc()
    {
        // Yavaþ dönme
        if (!isViewLocked)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        // Nesnenin belirlenen nokta etrafýnda dönmesi
        if (rotationPoint != null && !isViewLocked)
        {
            float angle = rotationSpeed * Time.deltaTime;
            transform.RotateAround(rotationPoint.position, Vector3.up, angle);
        }
    }

    // LockView fonksiyonu, drone'un kendi kendine dönmeyi durdurur ve sadece mouse ile döndürmeyi aktifleþtirir
    public void LockView()
    {
        isViewLocked = true;

        // LockView butonunu deaktif et
        lockButton.gameObject.SetActive(false);

        // UnlockView butonunu aktif et
        unlockButton.gameObject.SetActive(true);

        // "DroneParent" tag'ine sahip tüm nesnelerde dönmeyi durdur
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

    // UnlockView fonksiyonu, drone'un kendi kendine dönmeye devam etmesini saðlar ve mouse ile döndürmeyi aktifleþtirir
    public void UnlockView()
    {
        isViewLocked = false;

        // UnlockView butonunu deaktif et
        unlockButton.gameObject.SetActive(false);

        // LockView butonunu aktif et
        lockButton.gameObject.SetActive(true);

        // "DroneParent" tag'ine sahip tüm nesnelerde dönmeyi aktifleþtir
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
