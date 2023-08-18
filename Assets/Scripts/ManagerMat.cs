using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMat : MonoBehaviour
{

    public Material secondMaterial; // �kinci materyal

    public Renderer droneRenderer; // Renderer bile�enini burada saklayaca��z



    public void ChangeMaterials()
    {
        // E�er �u anki materyal birinci materyalse, ikinci materyali ata; aksi halde birinci materyali ata.
        Material newMaterial = secondMaterial;

        StartCoroutine(ChangeMaterialsCoroutine(newMaterial));
    }

    private System.Collections.IEnumerator ChangeMaterialsCoroutine(Material newMaterial)
    {
        // Yeni materyali dronun renderer'�na atay�n
        droneRenderer.sharedMaterial = newMaterial;
        yield return new WaitForSeconds(2.0f); // 2 saniye bekleyin
        droneRenderer.sharedMaterial = null;
        // �u anki materyali tekrar dronun renderer'�na atay�n
    }
}
