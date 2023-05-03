using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public InputField nameInputField;

    public TextMeshProUGUI bestScoreText;

    private void Start()
    {
        bestScoreText.text = "Best Score : " + DataPersistanceManager.Instance.bestScoreName + " " + DataPersistanceManager.Instance.bestScore;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
    }

    public void StoreName()
    {
        DataPersistanceManager.Instance.currentName = nameInputField.text;
    }
}
