using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelSwitch : MonoBehaviour
{
    public List<GameObject> drones = new List<GameObject>(); // Farklý drone'larý tutan liste
    public int currentDroneIndex = 0; // Þu anki drone'un indeksi

    public List<GameObject> drone2PropButtonsList = new List<GameObject>(); // drone2PropButtons GameObject'lerini tutan liste

 
    void Start()
    {
       
        SwitchToDrone(currentDroneIndex); // Baþlangýçta ilk droneu aktif hale getir
    }

    void Update()
    {
       
    }

    // Butonlara baðlanacak fonksiyonlar
    public void NextDrone()
    {
        currentDroneIndex++; // Bir sonraki drone'a geçmek için indeksi artýr
   
        if (currentDroneIndex >= drones.Count)

            currentDroneIndex = 0; // Eðer son dronea gelindiyse ilk dronea dön
       
        SwitchToDrone(currentDroneIndex);
    }

    public void PreviousDrone()
    {
        currentDroneIndex--; // Bir önceki drone'a geçmek için indeksi azalt
       
        if (currentDroneIndex < 0)
            currentDroneIndex = drones.Count - 1; // Eðer ilk drone'da geriye gidilmeye çalýþýlýrsa son drone'a geç
    
        SwitchToDrone(currentDroneIndex);
    }

    public void SwitchToDrone(int index)
    {
       
        if (index >= 0 && index < drones.Count)
        {
            DeactivateCurrentDroneComponents(); // Þu anki drone'un components'larýný deaktif hale getir

            // Tüm drone'larý deaktif hale getir
            foreach (GameObject drone in drones)
            {
                drone.SetActive(false);
            }

            // Yeni drone'u aktif hale getir
            drones[index].SetActive(true);
            ActivateCurrentDroneComponents();
        }
    }

    void ActivateCurrentDroneComponents()
    {
        // Þu anki drone'u aktif hale getir ve gerekli scriptleri etkinleþtir
        PropellerSwitch propellerSwitcher = drones[currentDroneIndex].GetComponent<PropellerSwitch>();
        if (propellerSwitcher)
            propellerSwitcher.enabled = true;

    }

    void DeactivateCurrentDroneComponents()
    {
        // Þu anki drone'u deaktif hale getir ve gerekli scriptleri devre dýþý býrak
        PropellerSwitch propellerSwitcher = drones[currentDroneIndex].GetComponent<PropellerSwitch>();
        if (propellerSwitcher)
            propellerSwitcher.enabled = false;

        // Diðer scriptleri de buraya ekleyebilirsiniz
    }

    public void DroneIndexUIControl()
    {

    }
}
