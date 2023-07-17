using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] private AudioSource doorhitSound;
    [SerializeField] private AudioSource runnerdieSound;
    [SerializeField] private AudioSource levelcompleteSound;
    [SerializeField] private AudioSource gameoverSound;
    [SerializeField] private AudioSource buttonSound;






    // Start is called before the first frame update
    void Start()
    {
        PlayerDetection.onDoorsHit += PlayDoorHitSound;
        GameManager.onGameStateChanged += GameStateChangedCallback;
        Enemy.onRunnerDie += RunnerDieSound;
    }
    private void OnDestroy()
    {
        PlayerDetection.onDoorsHit -= PlayDoorHitSound;
        GameManager.onGameStateChanged -= GameStateChangedCallback;
        Enemy.onRunnerDie -= RunnerDieSound;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void PlayDoorHitSound()
    {
        doorhitSound.Play();
    }
    private void RunnerDieSound()
    {
        runnerdieSound.Play();
    }
    private void GameStateChangedCallback(GameManager.GameState gameState)
    {
        if(gameState == GameManager.GameState.LevelComplete)
        {
            levelcompleteSound.Play();
        }else if(gameState == GameManager.GameState.Gameover)
        {
            gameoverSound.Play();
        }
    }
    public void DisableSounds()
    {
        doorhitSound.volume = 0;
        runnerdieSound.volume = 0;
        levelcompleteSound.volume = 0;
        gameoverSound.volume = 0;
        buttonSound.volume = 0;
    }
    public void EnableSounds()
    {
        doorhitSound.volume = 1;
        runnerdieSound.volume = 1;
        levelcompleteSound.volume = 1;
        gameoverSound.volume = 1;
        buttonSound.volume = 1;

    }
}
