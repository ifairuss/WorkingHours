using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class WindowContainers 
{
    public string Name;
    public GameObject Window;
}

public class ButtonActionInterface : MonoBehaviour
{
    public static ButtonActionInterface Instance { get; private set; }

    [Header("Window list")]
    [SerializeField] private List<WindowContainers> _allWindowContainers;

    [Header("Window components button")]
    [SerializeField] private Button _windowButton;
    [SerializeField] private Button _allWindowContainerClosedButton;

    [Header("Other")]
    [SerializeField] private GameObject _menuContainer;

    private void Awake()
    {
        Instance = this;
    }

    public void Initialized()
    {
        ClosedAllWindowOnStart();

        AllButtonAction();
    }

    private void ClosedAllWindowOnStart()
    {
        _allWindowContainerClosedButton.gameObject.SetActive(false);
        _allWindowContainers[0].Window.SetActive(false);
    }

    private void AllButtonAction()
    {
        _windowButton.onClick.AddListener(() =>
        {
            _allWindowContainerClosedButton.gameObject.SetActive(true);
            _allWindowContainers[0].Window.SetActive(true);
        });

        _allWindowContainerClosedButton.onClick.AddListener(() =>
        {
            for (int i = 1; i < _menuContainer.transform.childCount; i++)
            {
                _menuContainer.transform.GetChild(i).gameObject.SetActive(false);
            }
            _allWindowContainerClosedButton.gameObject.SetActive(false);
        });
    }
}
