using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneManagementManager : MonoBehaviour
{
    public bool isQuitConfirmUI;
    [SerializeField, HideInInspector] private GameObject _quitUICanvas;


    private void Start() => Initialized();


    public void Initialized()
    {
        if (isQuitConfirmUI)
            _quitUICanvas?.SetActive(false);
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
        {
            OnPrevButtonPressed();
        }
    }

    public void OnNextButtonPressed()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex > SceneManager.GetActiveScene().buildIndex)
        {
            nextSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

    public void OnPrevButtonPressed()
    {
        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;

        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
        else
        {
            if (!isQuitConfirmUI)
                QuitApplication();
            else
            {
                _quitUICanvas?.SetActive(true);
            }
        }
    }

    public void LoadScene(string _sceneName_)
    {
        SceneManager.LoadScene(_sceneName_);
    }

    public void OnIndexPressed(int _index_) => SceneManager.LoadScene(_index_);


    public void QuitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}