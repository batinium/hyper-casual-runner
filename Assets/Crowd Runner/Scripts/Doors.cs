using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BonusType { Addition, Difference, Product, Division }

public class Doors : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private SpriteRenderer rightDoorRenderer;
    [SerializeField] private SpriteRenderer leftDoorRenderer;
    [SerializeField] private TextMeshPro rightDoorText;
    [SerializeField] private TextMeshPro leftDoorText;
    [SerializeField] private Collider collider;


    [Header("Settings")]
    [SerializeField] private BonusType rightDoorBonusType;
    [SerializeField] private int rightDoorBonusAmount;

    [SerializeField] private BonusType leftDoorBonusType;
    [SerializeField] private int leftDoorBonusAmount;



    [SerializeField] private Color bonusColor;
    [SerializeField] private Color penaltyColor;

    // Start is called before the first frame update
    void Start()
    {
        ConfigureDoors();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void ConfigureDoors()
    {
        rightDoorBonusType = (BonusType)Random.Range(0, 4); // 0 to 3 (inclusive)
        leftDoorBonusType = (BonusType)Random.Range(0, 4); // 0 to 3 (inclusive)
        
        //configure the right door
        switch (rightDoorBonusType)
        {
            case BonusType.Addition:
                rightDoorBonusAmount = Random.Range(1, 11); // Random number between 1 and 10 (inclusive)
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "+" + rightDoorBonusAmount;
                break;
            case BonusType.Difference:
                rightDoorBonusAmount = Random.Range(1, 11); // Random number between 1 and 10 (inclusive)
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "-" + rightDoorBonusAmount;
                break;

            case BonusType.Product:
                rightDoorBonusAmount = Random.Range(1, 4); // Random number between 1 and 10 (inclusive)
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "X" + rightDoorBonusAmount;
                break;

            case BonusType.Division:
                rightDoorBonusAmount = Random.Range(1, 4); // Random number between 1 and 10 (inclusive)
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "/" + rightDoorBonusAmount;
                break;

        }
        switch (leftDoorBonusType)
        {
            case BonusType.Addition:
                leftDoorBonusAmount = Random.Range(2, 11); // Random number between 1 and 10 (inclusive)
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "+" + leftDoorBonusAmount;
                break;
            case BonusType.Difference:
                leftDoorBonusAmount = Random.Range(2, 11); // Random number between 1 and 10 (inclusive)
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "-" + leftDoorBonusAmount;
                break;

            case BonusType.Product:
                leftDoorBonusAmount = Random.Range(1, 3); // Random number between 1 and 10 (inclusive)
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "X" + leftDoorBonusAmount;
                break;

            case BonusType.Division:
                leftDoorBonusAmount = Random.Range(1, 3); // Random number between 1 and 10 (inclusive)
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "/" + leftDoorBonusAmount;
                break;

        }
    }
    public int GetBonusAmount(float xPosition)
    {
        if (xPosition > 0)
        {
            return rightDoorBonusAmount;
        }
        else
        {
            return leftDoorBonusAmount;
        }
    }
    public BonusType GetBonusType(float xPosition)
    {
        if (xPosition > 0)
        {
            return rightDoorBonusType;
        }
        else
        {
            return leftDoorBonusType;
        }
    }
    public void Disable()
    {
        collider.enabled = false;
    }
}