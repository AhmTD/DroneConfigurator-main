using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Image[] images;
    private int currentIndex = 0;

    void Start()
    {
        ShowImage(currentIndex);
    }

    public void NextImage()
    {
        currentIndex++;
        if (currentIndex >= images.Length)
            currentIndex = 0;

        ShowImageWithTween(currentIndex);
    }

    public void PreviousImage()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = images.Length - 1;

        ShowImageWithTween(currentIndex);
    }
    private void ShowImage(int index)
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(i == index);
        }
    }

    private void ShowImageWithTween(int index)
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
        }

        images[index].gameObject.SetActive(true);
        images[index].transform.localScale = Vector3.zero;

        images[index].transform.DOScale(Vector3.one, 0.5f).OnComplete(() =>
        {
            // Tween tamamlandýðýnda yapýlacak iþlemler
        });
    }

}
