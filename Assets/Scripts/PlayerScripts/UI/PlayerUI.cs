using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI goalText;

    [SerializeField] private string goalName;

    [SerializeField] private GameObject rightHand;

    private void Start() => ChangeRightHandVisibility(false);

    public void UpdatePromptText(string promptMessage) => promptText.text = promptMessage;

    public void UpdateHealth(int health) => healthText.text = $"Health: {health}";

    public void UpdateGoal(int currentGoalCount, int maxGoalCount) => goalText.text = $"{goalName}: {currentGoalCount}/{maxGoalCount}";

    public void ChangeRightHandVisibility(bool isVisible) => rightHand.SetActive(isVisible);

}
