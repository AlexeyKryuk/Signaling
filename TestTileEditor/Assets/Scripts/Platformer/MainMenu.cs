using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator _sunAnimator;

    public void OnPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnAuthors()
    {
        _sunAnimator.SetTrigger("Emerge");
    }
}
