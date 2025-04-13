using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public class SpriteData 
    {
        public string value;
        public Sprite sprite;
    }

    [Header("GameSettings")]
    [SerializeField] private TMP_InputField columnsInputField;
    [SerializeField] private TMP_InputField rowsInputField;
    [SerializeField] private Button beginButton;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject layoutChoicePanel;

    [Header("Grid Settings")]
    [SerializeField] private RectTransform buttonContainer;
    [SerializeField] private Vector2 cellSize = new Vector2(100, 100);
    [SerializeField] private Vector2 spacing = new Vector2(10, 10);

    [Header("Input Constraints")]
    [SerializeField] private int columnCeiling;
    [SerializeField] private int columnFloor;
    [SerializeField] private int rowCeiling;
    [SerializeField] private int rowFloor;

    [Header("Sprites")]
    [SerializeField] private List<SpriteData> spriteDataList = new List<SpriteData>();


    private List<SpriteData> CreateShuffledPairs(int totalButtons)
    {
        int pairCount = totalButtons / 2;
        List<SpriteData> selectedPairs = new List<SpriteData>();

        List<SpriteData> available = new List<SpriteData>(spriteDataList);

        for (int i = 0; i < pairCount; i++)
        {
            int index = Random.Range(0, available.Count);
            SpriteData selected = available[index];
            selectedPairs.Add(selected);
            selectedPairs.Add(selected);
        }

        for (int i = 0; i < selectedPairs.Count; i++)
        {
            int rnd = Random.Range(i, selectedPairs.Count);
            (selectedPairs[i], selectedPairs[rnd]) = (selectedPairs[rnd], selectedPairs[i]);
        }

        return selectedPairs;
    }
    private void GenerateGrid(int columns, int rows)
    {
        foreach (Transform child in buttonContainer)
            Destroy(child.gameObject);

        GridLayoutGroup gridLayout = buttonContainer.GetComponent<GridLayoutGroup>();
        gridLayout.cellSize = cellSize;
        gridLayout.spacing = spacing;
        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayout.constraintCount = columns;

        List<SpriteData> pairs = CreateShuffledPairs(columns * rows);

        for (int i = 0; i < pairs.Count; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonContainer);
            newButton.name = $"Button_{i}";

            GridButton gridButton = newButton.GetComponent<GridButton>();
            if (gridButton != null)
            {
                gridButton.AssignSpriteData(pairs[i]);
            }
        }
    }

    public void OnBegin()
    {
        if (int.TryParse(columnsInputField.text, out int columns) && int.TryParse(rowsInputField.text, out int rows))
        {
            if ((columns * rows) % 2 != 0)
            {
                Debug.Log("The total number of buttons must be an even number. Please adjust the rows or columns.");
                return;
            }

            if (columnCeiling > columns && columnFloor < columns && rowCeiling > rows && rowFloor < rows)
            {
                GenerateGrid(columns, rows);
                layoutChoicePanel.SetActive(false);
            }
        }
        else
        {
            Debug.Log("invalid input");
        }
    }
}
