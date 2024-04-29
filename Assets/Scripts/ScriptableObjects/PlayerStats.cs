using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerStats", menuName = "Player/Stats")]
public class PlayerStats : ScriptableObject
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private int minimumEnemiesToFinish = 3;

    public int MaxHealth { get => maxHealth; }
    public int MinimumEnemiesToFinish { get => minimumEnemiesToFinish; }

}
