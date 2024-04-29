using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public const string PLAYER_TAG = "Player";

    [SerializeField] private int playerHealth;
    [SerializeField] private int goal;
    [SerializeField] private PlayerStats playerStats;

    private PlayerUI playerUI;

    private bool hasGun = false;

    public static bool HasGun
    {
        get => Instance.hasGun;
        set
        {
            Instance.hasGun = value;
            Instance.playerUI.ChangeRightHandVisibility(value);
        }

    }

    private static int PlayerHealth
    {
        get => Instance.playerHealth;
        set
        {
            if (value > Instance.playerStats.MaxHealth)
                return;

            Instance.playerHealth = value;
            Instance.playerUI.UpdateHealth(value);

            if (value <= 0)
                OnPlayerKilled();
        }
    }

    private static int Goal
    {
        get => Instance.goal;
        set
        {
            Instance.goal = value;

            Instance.playerUI.UpdateGoal(value, Instance.playerStats.MinimumEnemiesToFinish);

            if (value >= Instance.playerStats.MinimumEnemiesToFinish)
                OnGameWon();

        }
    }

    private static PlayerManager Instance { get; set; }

    private void Awake() => Instance = this;

    private void Start()
    {
        playerUI = GetComponent<PlayerUI>();

        gameObject.tag = PLAYER_TAG;

        PlayerHealth = playerStats.MaxHealth;
        Goal = 0;
    }

    public static void IncrementEnemiesKilled() => ++Goal;
    public static void IncrementPlayerHealth() => ++PlayerHealth;
    public static void DecrementPlayerHealth() => --PlayerHealth;

    private static void OnPlayerKilled() => SceneManagerWrapper.LoadWorldScene();
    private static void OnGameWon() => SceneManagerWrapper.LoadEndScene();
}
