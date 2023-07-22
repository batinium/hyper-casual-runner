using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private ShopManager shopManager;

    [Header("Elements")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Slider progresBar;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private Text levelText;
    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private GameObject gamecompletePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject shopPanel;




    // Start is called before the first frame update
    void Start()
    {
        progresBar.value = 0;
        gamePanel.SetActive(false);
        gameoverPanel.SetActive(false);
        gamecompletePanel.SetActive(false);
        shopPanel.SetActive(false);
        settingsPanel.SetActive(false);

        levelText.text = "Level " + (ChunkManager.instance.GetLevel()+1);

        GameManager.onGameStateChanged += GameStateChangedCallback;  
    }
    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateProgressBar();
    }
    private void GameStateChangedCallback(GameManager.GameState gameState)
    {
        if(gameState == GameManager.GameState.Gameover)
        {
            ShowGameOverPanel();
        }
        else if(gameState == GameManager.GameState.LevelComplete)
        {
            ShowLevelComplete();
        }
    }
    public void PlayButtonPresseed()
    {
        GameManager.instance.SetGameState(GameManager.GameState.Game);
        menuPanel.SetActive(false); //disables the object, here it is the menu object
        gamePanel.SetActive(true);
    }
    public void UpdateProgressBar()
    {
        if (GameManager.instance.IsGameState())
        {
            float progress = PlayerController.instance.transform.position.z / ChunkManager.instance.GetFinishLineZ();
            progresBar.value = progress;
            Debug.Log("updated");
        }
        else
        {
            return;
        }
        
    }
    public void RetryButtonPressed()
    {
        SceneManager.LoadScene(0);
    }
    public void ShowGameOverPanel()
    {
        gamePanel.SetActive(false);
        gameoverPanel.SetActive(true);
    }
    public void ShowLevelComplete()
    {
        gamePanel.SetActive(false);
        gamecompletePanel.SetActive(true);
    }
    public void ShowSettingsPanel()
    {
        settingsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }
    public void HideSettingsPanel()
    {
        settingsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
    public void ShowShopPanel()
    {
        shopPanel.SetActive(true);
        shopManager.UpdatePurchaseButton();
    }
    public void HideShopPanel()
    {
        shopPanel.SetActive(false);

    }

}
