using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private Image image;
    [SerializeField] private Text textButton;
    [SerializeField] private GameObject mainMenu;

    private int counter = 0;

    public void ClickNext()
    {
        counter++;
        if (counter < 3)
        {
            image.sprite = sprite[counter];
            if (counter == 2) textButton.text = "BACK";
        }
        else if (counter == 3) 
        {
            counter = 0;
            mainMenu.SetActive(true);
            gameObject.SetActive(false);
            textButton.text = "NEXT";
            image.sprite = sprite[counter];  
        }
    }
}