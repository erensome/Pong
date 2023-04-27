using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanelToggle : MonoBehaviour
{
    [SerializeField]
    private RectTransform InfoPanel;
    [SerializeField]
    public GameObject DifficultyParent;
    public void TogglePanel()
    {
        bool state = InfoPanel.gameObject.activeInHierarchy;
        InfoPanel.gameObject.SetActive(!state);
        DifficultyParent.SetActive(state);
    }
}
