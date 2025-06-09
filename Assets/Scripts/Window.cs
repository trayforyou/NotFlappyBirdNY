using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowsGroup;
    [SerializeField] private Button _actionButton;

    protected CanvasGroup WindowsGroup => _windowsGroup;
    protected Button ActionButton => _actionButton;

    private void Awake()
    {
        _actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnApplicationQuit()
    {
        _actionButton.onClick.RemoveListener(OnButtonClick);
    }

    protected abstract void OnButtonClick();

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }
}