using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("GameSettings")]
    [SerializeField] private TMP_InputField columns;
    [SerializeField] private TMP_InputField rows;
    [SerializeField] private Button beginButton;

    [Header("Grid Settings")]
    [SerializeField] private Vector2 cellSize = new Vector2(100, 100);
    [SerializeField] private Vector2 spacing = new Vector2(10, 10);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
