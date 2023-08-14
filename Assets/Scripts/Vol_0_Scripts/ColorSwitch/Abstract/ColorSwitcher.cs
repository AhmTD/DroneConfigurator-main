using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ColorSwitcher : MonoBehaviour
{
    public Material[] materials;

    protected int currentMaterialIndex;
    protected int activeDroneIndex;

    public abstract void ChangeMaterial();
    public abstract void SetActiveMaterial(int materialIndex);

}
