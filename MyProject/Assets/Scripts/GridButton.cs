using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class GridButton : MonoBehaviour
{
    [SerializeField] private GameObject hiddenImageGO;
    [SerializeField] private Image hiddenImage;
    public string assignedValue { get; private set; }


    private void Awake()
    {
        //AssignRandomSprite();
    }

    public void RevealImage() 
    {
        if (hiddenImage.sprite != null)
        {
            hiddenImageGO.SetActive(true);
        }
    }

    public void AssignSpriteData(SpriteData data) 
    {
        hiddenImage.sprite = data.sprite;
        assignedValue = data.value;
        hiddenImageGO.SetActive(false);
    }
}
