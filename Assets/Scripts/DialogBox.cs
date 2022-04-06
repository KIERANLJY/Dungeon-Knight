using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    public GameObject _dialogBox;

    public void ShowDialogBox()
    {
        _dialogBox.SetActive(true);
    }

    public void HideDialogBox()
    {
        _dialogBox.SetActive(false);
    }
}
