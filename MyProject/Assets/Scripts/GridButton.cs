using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridButton : MonoBehaviour
{
    [SerializeField] private Sprite[] spritesArray = new Sprite[5];
    [SerializeField] private GameObject hiddenImageGO;
    [SerializeField] private Image hiddenImage;

    private void Awake()
    {
        AssignRandomSprite();
    }

    public void RevealImage() 
    {
        if (hiddenImage.sprite != null)
        {
            hiddenImageGO.SetActive(true);
        }
    }

    private void AssignRandomSprite() 
    {
        if (spritesArray == null || spritesArray.Length == 0) 
        {
            Debug.Log($"no sprites assigned on {gameObject.name}");
            return;
        }

        hiddenImage.sprite = spritesArray[Random.Range(0, spritesArray.Length)];
    }
}
