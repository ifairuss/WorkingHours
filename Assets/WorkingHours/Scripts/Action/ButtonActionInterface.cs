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
    [SerializeField] private Button _preferencesButton;
    [SerializeField] private MenuButtonAnimations _menuAnimationScript;

    [Header("Other")]
    [SerializeField] private GameObject _menuContainer;

    private bool _windowMenuisOpen;

    private void Awake()
    {
        Instance = this;
    }

    public void Initialized()
    {
        _windowMenuisOpen = false;

        ClosedAllWindowOnStart();

        AllButtonAction();
    }

    private void ClosedAllWindowOnStart()
    {
        _allWindowContainers[0].Window.SetActive(false);
        _allWindowContainers[1].Window.SetActive(false);
    }

    private void AllButtonAction()
    {
        _windowButton.onClick.AddListener(() =>
        {
            if (!_windowMenuisOpen)
            {
                _allWindowContainers[0].Window.SetActive(true);
                _windowMenuisOpen=true;
                _menuAnimationScript.AnimationButton(_windowMenuisOpen);
            }
            else
            {
                _allWindowContainers[0].Window.SetActive(false);
                _windowMenuisOpen = false;
                _menuAnimationScript.AnimationButton(_windowMenuisOpen);
            }
        });

        _preferencesButton.onClick.AddListener(() => { _allWindowContainers[1].Window.SetActive(true); });
    }
}
