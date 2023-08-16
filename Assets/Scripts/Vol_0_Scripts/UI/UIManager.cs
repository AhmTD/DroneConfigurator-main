using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public ModelSwitch modelSwitch;
    public int activeDroneIndex = 0;
    public Image backGroundColor;
    public float opacityReductionAmount = 0.1f;

    public GameObject[] gameObjects;



    // Start is called before the first frame update
    void Start()
    {



        modelSwitch = GameObject.Find("ModelManager").GetComponent<ModelSwitch>();
    }
    private void Update()
    {
        activeDroneIndex = modelSwitch.currentDroneIndex;
        {
         
            if (activeDroneIndex != 0)
            {
                // Ýlk olarak resmin orijinal renk deðerini al
                Color originalColor = backGroundColor.color;

                // Alpha bileþenini azalt
                Color newColor = originalColor;
                newColor.a = opacityReductionAmount;

                // Resmin rengini güncelle
                backGroundColor.color = newColor;

                for (int i = 0; i <gameObjects.Length ; i++)
                {
                    gameObjects[i].SetActive(false);

                }
            }
            else
            {
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    gameObjects[i].SetActive(true);

                }
            }
        }
    }
}
