using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPropellerSwitchers : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> backPropellerListD0;
    public void ChangeObject(int index)
    {

        for (int i = 0; i < backPropellerListD0.Count; i++)
        {
            GameObject propeller = backPropellerListD0[i];
            propeller.SetActive(i == index);
        }
    }

}
