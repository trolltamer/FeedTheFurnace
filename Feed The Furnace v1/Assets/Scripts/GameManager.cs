using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

/*
 GameManager is a static singleton class that controls some key game functions like starting and pausing the game,
 and is also the central dependency injection system for a variety of classes, and holds game data in a centrally accessible place.
 */


[RequireComponent(typeof(PlayerManager),typeof(GameData),typeof(SpawnManager))]
public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public GameData GameData;
    public PlayerManager PlayerManager;
    public SpawnManager SpawnManager;
    public GoalArea GoalArea;
    public BoundaryArea BoundaryArea;
    public UIManager gmUIManager;
    public WardrobeManager WardrobeManager;


    // Use this for initialization
    void Awake () {

        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(this.gameObject);

        GameData = GetComponent<GameData>();
        PlayerManager = GetComponent<PlayerManager>();
        GoalArea = Instantiate(GameData.GoalAreaPrefab).GetComponent<GoalArea>();
        SpawnManager = GetComponent<SpawnManager>();
        WardrobeManager = GetComponent<WardrobeManager>();
        GameData.currentGameScore.Value = 0f;
        GameData.currentScoreMultiplier.Value = 0f;
        PauseGame();
    }

    public void AddScore()
    {
        //Debug.Log("adding Score");
        GameData.currentGameScore.Value += Mathf.Max(1, (GameData.currentScoreMultiplier.Value));
        GameData.currentScoreMultiplier.Value++;

        //was originally calling these UI update functions via the AddScoreSO event but there was a race condition emerging between GM.AddScore and UIManager.UpdateScore, both subscribed to same score event
        //using these direct function calls seems simplest since these managers already reference eachoether
        gmUIManager.UpdateScore();
        gmUIManager.UpdateCombo();
    }

    public void GameOver()
    {
        Debug.Log("Game Over! Try again!");
        PauseGame();
    }

    public void ResetScoreMultiplier()
    {
        GameData.currentScoreMultiplier.Value = 0;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void StartGame() {
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
