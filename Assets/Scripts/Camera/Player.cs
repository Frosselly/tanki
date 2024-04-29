using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    [Header("Player state")]
    [SerializeField, Min(0)]
    private int lives = 3;

    [SerializeField, Min(0)]
    private int ammo = 5;

    [Header("UI")]
    [SerializeField]
    private TextMeshProUGUI livesText;

    [SerializeField]
    private TextMeshProUGUI ammoText;

    [SerializeField]
    private TextMeshProUGUI gameOverText;

    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateLivesText();
        UpdateAmmoText();
    }

    private void UpdateLivesText()
    {
        livesText.text = $"Lives: {lives}";
    }

    private void UpdateAmmoText()
    {
        ammoText.text = $"Ammo: {ammo}";
    }

    public void TakeDamage()
    {
        lives--;
        UpdateLivesText();

        if(lives <= 0)
        {
            StopGame();
        }
    }

    private void StopGame()
    {
        playerController.enabled = false;
        gameOverText.gameObject.SetActive(true);
    }

    public void AddLives(int value)
    {
        lives += value;
        UpdateLivesText();
    }

    public void AddAmmo(int value)
    {
        ammo += value;
        UpdateAmmoText();
    }
}
