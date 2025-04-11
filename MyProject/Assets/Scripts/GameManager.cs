using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GenerateGrid(int columns, int rows) 
    {
        foreach (Transform child in buttonContainer)
        {
            Destroy(child.gameObject);
        }

        GridLayoutGroup gridLayout = buttonContainer.GetComponent<GridLayoutGroup>();

        gridLayout.cellSize = cellSize;
        gridLayout.spacing = spacing;

        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayout.constraintCount = columns;
        

        for (int i = 0; i < rows * columns; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonContainer);
            newButton.name = $"Button_{i}";
        }
    }

    public void OnBegin()
    {
        if (int.TryParse(columnsInputField.text, out int columns) && int.TryParse(rowsInputField.text, out int rows))
        {
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
