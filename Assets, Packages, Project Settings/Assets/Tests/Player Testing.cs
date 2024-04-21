using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTesting
{
    private GameObject game;

    [SetUp]
    public void Setup()
    {
        game = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Game_Level"));
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(game);
    }

    [Test]
    public void _01_GamePrefabExists()
    {
        Assert.IsNotNull(game);
    }

    [Test]
    public void _02_GameOverWhenPlayersHealthReachesZero()
    {
        Game_Control.Player_Health = 0; //Kills the player

        Assert.True(Game_Control.Game_Over_UI_Enabled);
    }

    [UnityTest]
    public IEnumerator _03_UpgradeMenuOpensAfterLevelingUp()
    {
        Game_Control.Player_XP = Game_Control.Player_XP_To_Level; //Levels up the player

        yield return new WaitForSecondsRealtime(0.1f);

        Assert.True(Game_Control.UpgradeMenuOpen);
    }

    [Test]
    public void _04_GamePauses()
    {
        Game_Control.PauseGame();

        Assert.True(Time.timeScale == 0);
    }

    [UnityTest]
    public IEnumerator _05_GameResumes()
    {
        Game_Control.PauseGame();
        yield return new WaitForSecondsRealtime(0.1f);
        Game_Control.ResumeGame();

        Assert.True(Time.timeScale == 1);
    }

    [Test]
    public void _06_PlayerCreated()
    {
        Assert.True(GameObject.FindGameObjectWithTag("Player"));
    }

    [UnityTest]
    public IEnumerator _07_EnemySpawned()
    {
        yield return new WaitForSecondsRealtime(0.1f);

        Assert.True(GameObject.FindGameObjectWithTag("Basic Enemy"));
    }

    [UnityTest]
    public IEnumerator _08_PlayerTakesDamageFromEnemy()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator _09_EnemyTakesDamageFromPlayerBullet()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator _10_PlayerProjectileMoves()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator _11_PlayerTakesDamageFromEnemy()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator _12_AttackUpgradeIncreaseBulletDamage()
    {
        Game_Control.Attack_Damage_Upgrade_Level++;

        yield return null;
    }

    [UnityTest]
    public IEnumerator _13_AttackSpeedUpgradeIncreaseFireRate()
    {
        Game_Control.Attack_Speed_Upgrade_Level++;

        yield return null;
    }

    [UnityTest]
    public IEnumerator _14_AttackSizeUpgradeIncreaseBulletScale()
    {
        Game_Control.Attack_Size_Upgrade_Level++;

        yield return null;
    }

    [UnityTest]
    public IEnumerator _15_MaxHealthUpgradeIncreasePlayerHealth()
    {
        Game_Control.Health_Upgrade_Level++;

        yield return null;
    }

    [UnityTest]
    public IEnumerator _16_PlayerSpeedUpgradeIncreasePlayerMovementSpeed()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator _17_ProjectileDurationUpgradeIncreaseProjectileLifeSpan()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator _18_UpdatePlayerStats()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator _19_ResetPlayerStats()
    {
        yield return null;
    }

    [UnityTest]
    public IEnumerator _20_SpawnUpgradeChoice()
    {
        yield return null;
    }
}
