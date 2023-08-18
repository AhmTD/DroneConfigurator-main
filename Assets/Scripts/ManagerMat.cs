using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMat : MonoBehaviour
{

    public Material secondMaterial; // Ýkinci materyal

    public Renderer droneRenderer; // Renderer bileþenini burada saklayacaðýz



    public void ChangeMaterials()
    {
        // Eðer þu anki materyal birinci materyalse, ikinci materyali ata; aksi halde birinci materyali ata.
        Material newMaterial = secondMaterial;

        StartCoroutine(ChangeMaterialsCoroutine(newMaterial));
    }

    private System.Collections.IEnumerator ChangeMaterialsCoroutine(Material newMaterial)
    {
        // Yeni materyali dronun renderer'ýna atayýn
        droneRenderer.sharedMaterial = newMaterial;
        yield return new WaitForSeconds(2.0f); // 2 saniye bekleyin
        droneRenderer.sharedMaterial = null;
        // Þu anki materyali tekrar dronun renderer'ýna atayýn
    }
}
