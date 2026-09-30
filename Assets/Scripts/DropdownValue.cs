using UnityEngine;
using System.Collections.Generic;
using TMPro; 
using UnityEngine.SceneManagement;

public class DropdownValue : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;
    [SerializeField] private TMP_Text _text;

    private string _startScene = "Sample Scene"; 
    private string _selectedValue;
    
    private void Start()
    {
        _selectedValue = _dropdown.options[_dropdown.value].text;
        
        _dropdown.onValueChanged.AddListener(OnDropDownChanged);
    }

    private void OnDestroy()
    {
        _dropdown.onValueChanged.RemoveListener(OnDropDownChanged);;
    }

    private void OnDropDownChanged(int _index_)
    {
        _selectedValue = _dropdown.options[_index_].text;
        
        Debug.Log("Selected Value: " + _selectedValue);
    }

    public void StartScene()
    {
        Debug.Log("Starting Scene: " + _selectedValue);

        // Check if scene exists before loading
        if (Application.CanStreamedLevelBeLoaded(_selectedValue))
        {
            SceneManager.LoadScene(_selectedValue);
        }
        else
        {
            Debug.LogError("Scene not found: " + _selectedValue);
        }
    }
}
