using System;
using TMPro;
using UnityEngine;

public class TooltipUI : MonoBehaviour
{
    public static TooltipUI Instance;

    public GameObject tooltipPanel;
    public TextMeshProUGUI tooltipText;

    void Awake()
    {
        Instance = this;
        Hide();
    }

    public void Show(String text, Vector2 position)
    {
        tooltipPanel.SetActive(true);
        tooltipText.text = text;
        tooltipPanel.transform.position = position;
    }

    public void Hide()
    {
        tooltipPanel.SetActive(false);
    }

    void Start()
    {
        Cursor.visible = true;
    }

    void Update()
    {
        if (tooltipPanel.activeSelf)
        {
            tooltipPanel.transform.position = Input.mousePosition;
        }
    }
}
