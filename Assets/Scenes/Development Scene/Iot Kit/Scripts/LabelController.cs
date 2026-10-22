using UnityEngine;

public class LabelController : MonoBehaviour
{
    public static LabelController Instance { get; private set; }

    [Header("All Labels In Scene")]
    [SerializeField] private GameObject[] _labels;

    private int _currentLabelIndex = -1;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // Disable all labels when the scene starts.
        foreach (GameObject label in _labels)
        {
            if (label != null)
                label.SetActive(false);
        }
    }

    public void ToggleLabel(int labelIndex)
    {
        if (labelIndex < 0 || labelIndex >= _labels.Length)
        {
            Debug.LogWarning("Invalid label index: " + labelIndex);
            return;
        }

        GameObject selectedLabel = _labels[labelIndex];

        if (selectedLabel == null)
            return;

        // Clicking the currently active label toggles it off.
        if (_currentLabelIndex == labelIndex)
        {
            selectedLabel.SetActive(false);
            _currentLabelIndex = -1;
            return;
        }

        // Disable the previous label.
        if (_currentLabelIndex >= 0 && _currentLabelIndex < _labels.Length && _labels[_currentLabelIndex] != null)
        {
            _labels[_currentLabelIndex].SetActive(false);
        }

        // Activate the selected label.
        selectedLabel.SetActive(true);
        _currentLabelIndex = labelIndex;
    }
}