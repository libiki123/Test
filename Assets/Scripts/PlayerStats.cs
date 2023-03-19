using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private Character_SO playerData;
    [SerializeField] private List<GameObject> spawnedWeapons = new List<GameObject>();

    [HideInInspector] public float currentMoveSpeed;
    private float currentMaxHealth;
    private float currentRecovery;
    [HideInInspector] public float currentMagnet;

    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrase;
    }

    [Header("Experience/Level")]
    [SerializeField] private int experience = 0;
    [SerializeField] private int level = 1;
    [SerializeField] private int experiecnCap;
    [SerializeField] private List<LevelRange> levelRanges = new List<LevelRange>();

    [Header("IFrames")]
    [SerializeField] private float invincibilityDuration;
    private float invincibilityTimer;
    private bool isInvincible = false;

    [Header("Weapons")]
    [SerializeField] List<GameObject> weaponPrefabs = new List<GameObject>();

    [Header("UI stats")]
    [SerializeField] private Image hpUI;
    [SerializeField] private TMP_Text levelUI;

    private void Awake()
    {
        currentMoveSpeed = playerData.MoveSpeed;
        currentMaxHealth = playerData.MaxHealth;
        currentRecovery = playerData.Recovery;
        currentMagnet = playerData.Magnet;

        SpawnWeapon(playerData.StartingWeapon);
        UpdateUI();
    }

    private void Start()
    {
        experiecnCap = levelRanges[0].experienceCapIncrase;
    }

    private void Update()
    {
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;

            if(invincibilityTimer <= 0)
            {
                isInvincible = false;
            }
        }
    }

    public void IncreaseExperience(int amount)
    {
        experience += amount;
        LevelUpCheck();
    }

    public void Heal(int amount)
    {
        if(currentMaxHealth < playerData.MaxHealth)
        {
            currentMaxHealth += amount;

            if (currentMaxHealth > playerData.MaxHealth)
            {
                currentMaxHealth = playerData.MaxHealth;
            }
        }

        UpdateUI();
    }

    private void LevelUpCheck()
    {
        if(experience >= experiecnCap)
        {
            level++;
            experience -= experiecnCap;
            GrantNewWeapon();
            UpdateUI();

            int experienceCapIncrease = 0;
            foreach(LevelRange range in levelRanges)
            {
                if(level >= range.startLevel && level <= range.endLevel)
                {
                    experienceCapIncrease = range.experienceCapIncrase;
                    break;
                }
            }

            experiecnCap += experienceCapIncrease;
        }
    }

    private void GrantNewWeapon() // TEMPORARY, NEED IMPROVE ON THIS SYSTEM
    {
        if (level < 5)
            SpawnWeapon(weaponPrefabs[level-2]);
    }

    public void TakeDamage(float dmg)
    {
        if (isInvincible) return;

        currentMaxHealth -= dmg;
        invincibilityTimer = invincibilityDuration;
        isInvincible = true;
        UpdateUI();

        if (currentMaxHealth <= 0)
        {
            Kill();
        }
    }

    private void UpdateUI()
    {
        if (currentMaxHealth <= 0) return;
        hpUI.fillAmount = math.remap(0, playerData.MaxHealth, 0, 1, currentMaxHealth);
        levelUI.text = level.ToString();
    }

    public void SpawnWeapon(GameObject weapon)
    {
        GameObject spawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        spawnedWeapon.transform.parent = transform;
        spawnedWeapons.Add(spawnedWeapon);
    }

    public void Kill()
    {
        Debug.Log("Player Die");
        UIManager.instance.ShowEndGame();
    }

}
