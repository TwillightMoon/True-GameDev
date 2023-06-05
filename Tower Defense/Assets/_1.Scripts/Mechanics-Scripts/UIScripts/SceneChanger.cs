using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private GameObject _startGameButton;

    public void SceneChange(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void StartGame()
    {
        SceneChange(1);
    }

    public void ShowSetting()
    {
        if (!_settingPanel) return;

        if (_startGameButton) _startGameButton.SetActive(false);

        _settingPanel.SetActive(true);

    }
    public void HideSetting()
    {
        if (!_settingPanel) return;

        if (_startGameButton) _startGameButton.SetActive(true);

        _settingPanel.SetActive(false);
    }
}
