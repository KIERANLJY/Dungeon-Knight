using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecordLoading : MonoBehaviour
{
    public void LoadRecord()
    {
        SceneManager.LoadScene(2);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
