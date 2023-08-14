using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectSwitcher : MonoBehaviour
{
    protected int currentIndex;
    public abstract void ChangeObject(int index);

    public abstract void ToRightChangerFuncButton();
   

    public abstract void ToLeftChangerFuncButton();
   
}
