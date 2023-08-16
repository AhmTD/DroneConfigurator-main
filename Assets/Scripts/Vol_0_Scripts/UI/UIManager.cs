using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public ModelSwitch modelSwitch;
    public int activeDroneIndex = 0;
    public GameObject backPropeller;
    public Image mainImage;
    public Image changeImage;
    public GameObject[] gameObjects;
    public GameObject[] icon;



    // Start is called before the first frame update
    void Start()
    {
        modelSwitch = GameObject.Find("ModelManager").GetComponent<ModelSwitch>();
    }
    private void Update()
    {
        activeDroneIndex = modelSwitch.currentDroneIndex;
       

        if (activeDroneIndex != 0)
        {
            Image image = backPropeller.GetComponent<Image>();
            image.sprite = changeImage.sprite;

            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(false);
                icon[i].SetActive(false);

            }
        }
        else
        {
            Image image = backPropeller.GetComponent<Image>();
            image.sprite= mainImage.sprite;
            for (int i = 0; i < gameObjects.Length; i++)
            {
      
                gameObjects[i].SetActive(true);
                icon[i].SetActive(true);
            }
        }

    }

   
    
       
    
}
