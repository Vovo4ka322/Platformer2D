using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    private const string Game = nameof(Game);

    public void PressButton()
    {
        SceneManager.LoadScene(Game);
    }
}
