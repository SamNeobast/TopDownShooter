using UnityEngine;
using System;
using TMPro;

public class ChangeAmountKills : MonoBehaviour
{
    public static Action OnKilledEnemy;

    [SerializeField] private TextMeshProUGUI amountKillUI;
    private int amountKill;

    private void Start()
    {
        OnKilledEnemy += ChangeText;
    }

    private void ChangeText()
    {
        amountKill++;
        amountKillUI.text = "Killed: " + amountKill;
    }

    private void OnDestroy()
    {
        OnKilledEnemy -= ChangeText;
    }
}
