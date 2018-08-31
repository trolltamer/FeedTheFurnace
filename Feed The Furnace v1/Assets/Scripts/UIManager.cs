using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

/*The UI Manager holds references to each of the ui objects to update and transitions between them on certain event calls
 *   Contains several methods for activating or deactivating certain state based UI's (gameplay, pause, wardrobe etc), along with events that are called simultaneously
 *   The functions of this method are almost entirely called through buttons
 *   To be extended with functions to control animation based transitions*/

public class UIManager : MonoBehaviour {


    public GameObject MainMenuParent;

    public GameObject GameplayUIParent;
    public TextMeshProUGUI ScoreTMP;
    public TextMeshProUGUI ComboTMP;

    public GameObject PausedUIParent;

    public GameObject WardobeUIParent;

    public EventScriptableObject GamePausedSO;
    public EventScriptableObject GamePlayedSO;
    public EventScriptableObject GameRestartSO;


    private void Start()
    {
        SetMainMenuUIActive();
    }
    
    public void DisableAllUI()
    {
        MainMenuParent.SetActive(false);
        GameplayUIParent.SetActive(false);
        PausedUIParent.SetActive(false);
        WardobeUIParent.SetActive(false);
    }

    public void SetMainMenuUIActive()
    {
        DisableAllUI();
        MainMenuParent.SetActive(true);
    }

    public void SetGameUIActive()
    {
        GamePlayedSO.Raise();
        DisableAllUI();
        GameplayUIParent.SetActive(true);
    }

    public void SetPauseUIActive()
    {
        GamePausedSO.Raise();
        PausedUIParent.SetActive(true);
    }

    public void SetWardrobeUIActive()
    {
        DisableAllUI();
        WardobeUIParent.SetActive(true);
    }

    public void RestartGame()
    {
        GameRestartSO.Raise();
    }

    public void UpdateScore()
    {
        //Debug.Log("ui updating score display text");
        ScoreTMP.text = ("SCORE: " + GameManager.Instance.GameData.currentGameScore.Value);

    }

    public void UpdateCombo()
    {
        //Debug.Log("ui updating combo display text");
        ComboTMP.text = ("COMBO: " + GameManager.Instance.GameData.currentScoreMultiplier.Value);
    }
}
