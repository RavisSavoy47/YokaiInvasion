using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instace;
    public GameState State;
    public static event System.Action<GameState> OnGmaeStateChange;
    private EnemySpawnerBehavior enemySpawnerBehavior;
    private int _playerScore, _enemyCount;
    public Text _enemycount;
    private void Awake()  { Instace = this; }
    private void Start()
    {
        _enemycount.text = "Score: " + _playerScore.ToString();
        caculatePoint();
    }
    // Update is called once per frame
    void Update()
    {
        if (_enemyCount == 0)
        {
            //EnemyHolderManager.Instace.setActiveSpawners();
            UpdateGamestate(GameState.AdvanceForward);
        }
    }

    public void UpdateGamestate(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.Startmenu:
                SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
                break;
            case GameState.MainGameScene:
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
                break;
            case GameState.SpawnWave:
                EnemyHolderManager.Instace.setActiveSpawners();
                break;
            case GameState.AdvanceForward:
                EnvironmentSpawnerHolder.Instace.setActiveSpawners();
                break;
            case GameState.EndScreen:
                SceneManager.LoadScene("DeathScene",LoadSceneMode.Single );
                break;
            default:
                break;
        }
        OnGmaeStateChange?.Invoke(newState);
    }
    public void caculatePoint()
    {
        _enemyCount = enemySpawnerBehavior.EnemyCount;
    }
    public void AddPoint()
    {
        _enemyCount += 1;
        _enemycount.text = "Score: " + _playerScore.ToString();
    }
    public void SubtractPoint()
    {
        _playerScore++;
        _enemyCount -= 1;
        _enemycount.text = "Score: " + _playerScore.ToString();
    }
}

public enum GameState { 
    Startmenu,
    MainGameScene,
    SpawnWave,
    AdvanceForward,
    EndScreen
}