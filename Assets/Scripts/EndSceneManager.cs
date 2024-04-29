using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] private Button restartButton;

    private void Start()
    {
        restartButton.onClick.AddListener(SceneManagerWrapper.LoadWorldScene);
    }
}
