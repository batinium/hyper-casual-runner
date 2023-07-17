using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    public enum GameState { Menu, Game, LevelComplete, Gameover};
    public static GameManager instance;
    private GameState gameState;
    public static Action<GameState> onGameStateChanged; //when the gamestate changes it will send a signal

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        onGameStateChanged?.Invoke(gameState);//if no one listenes to event, without ? it gives an error.
        Debug.Log("GameState changed to: " + gameState);
    }
    public bool IsGameState()
    {
        return gameState == GameState.Game;
    }
}
