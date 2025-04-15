using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class GridButton : MonoBehaviour
{
    [SerializeField] private GameObject hiddenImageGO;
    [SerializeField] private GameObject coatImageGO;
    [SerializeField] private Image hiddenImage;
    public string assignedValue { get; private set; }

    private GameManager gameManager;

    public void Initialize(GameManager manager)
    {
        gameManager = manager;
    }

    public void OnClick() 
    {
        if(gameManager != null) 
        {
            gameManager.SelectButton(this);
        }
        else 
        {
            Debug.LogError("GameManager is not initialized");
        }
    }

    public void RevealImage() 
    {
        if (hiddenImage.sprite != null)
        {
            hiddenImageGO.SetActive(true);
        }
    }

    public void HideImage()
    {
        if (hiddenImage.sprite != null)
        {
            hiddenImageGO.SetActive(false);
        }
    }

    public void DisableImage() 
    {
        coatImageGO.SetActive(false);
    }

    public void AssignSpriteData(SpriteData data) 
    {
        hiddenImage.sprite = data.sprite;
        assignedValue = data.value;
    }
}
