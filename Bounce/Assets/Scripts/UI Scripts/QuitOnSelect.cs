using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnSelect : MonoBehaviour
{
    /// <summary>
    /// Quits the application.
    /// NOTE: will not work in editor.
    /// </summary>
    public void OnSelect()
    {
        Application.Quit();
    }
}
