using System;
using UnityEngine;

public class UnitSelectionManagerUI : MonoBehaviour
{
    [SerializeField] private RectTransform _selectionAreaRectTransform;

    private void Start()
    {
        UnitSelectionManager.Instance.OnSelectStart += OnSelectStart;
        UnitSelectionManager.Instance.OnSelectEnd += OnSelectEnd;
        
        _selectionAreaRectTransform.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_selectionAreaRectTransform.gameObject.activeSelf) UpdateVisual();
    }

    private void OnSelectStart(object sender, EventArgs e)
    {
        _selectionAreaRectTransform.gameObject.SetActive(true);
        UpdateVisual();
    }

    private void OnSelectEnd(object sender, EventArgs e)
    {
        _selectionAreaRectTransform.gameObject.SetActive(false);
    }

    private void UpdateVisual()
    {
        Rect selectionAreaRect = UnitSelectionManager.Instance.GetSelectionArea();

        _selectionAreaRectTransform.anchoredPosition = 
            new Vector2(selectionAreaRect.x, selectionAreaRect.y);
        _selectionAreaRectTransform.sizeDelta = 
            new Vector2(selectionAreaRect.width, selectionAreaRect.height);
    }
}
