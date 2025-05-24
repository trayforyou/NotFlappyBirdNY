using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : Window
{
    public event Action RestartButtonClicked;

    public override void Close()
    {
        WindowsGroup.alpha = 0;
        ActionButton.interactable = false;
    }

    public override void Open()
    {
        WindowsGroup.alpha = 1;
        ActionButton.interactable = true;
    }

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}
