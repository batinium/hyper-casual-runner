using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Elements")]
    [SerializeField] private CrowdSystem crowdSystem;

    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    private bool canMove;


    [Header("Control")]
    [SerializeField] private float slideSpeed;
    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPoisiton;
    [SerializeField] private float roadWidth;
    [SerializeField] private PlayerAnimator playerAnimator;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //listen to the game state change
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }
    private void OnDestroy()
    {//unsubscribe from the event when reloading
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove == true)
        {
            MoveForward();
            ManageControl();
        }
        
    }
    private void GameStateChangedCallback(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.Game)
        {
            StartMoving();
        } else if (gameState == GameManager.GameState.Gameover || gameState == GameManager.GameState.LevelComplete)
        {
            StopMoving();
        }
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }
    private void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPoisiton = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;

            xScreenDifference /= Screen.width;

            xScreenDifference *= slideSpeed;
            Vector3 position = transform.position;
            position.x = clickedPlayerPoisiton.x + xScreenDifference;

            position.x = Mathf.Clamp(position.x, -roadWidth / 2 + crowdSystem.GetCrowdRadius(),roadWidth / 2 - crowdSystem.GetCrowdRadius());

            transform.position = position;

        }
    }
    private void StartMoving()
    {
        canMove = true;
        playerAnimator.Run();
    }
    private void StopMoving()
    {
        canMove = false;
        playerAnimator.Idle();
    }
}
