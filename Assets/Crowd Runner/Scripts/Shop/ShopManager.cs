using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class ShopManager : MonoBehaviour
{
    [Header("Skins")]
    [SerializeField] private Button purchaseButton;
    [SerializeField] private Sprite[] skins;
    [Header("Elements")]
    [SerializeField] private SkinButton[] skinButtons;
    [Header("Pricing")]
    [SerializeField] private int skinPrice;
    [SerializeField] private TextMeshProUGUI priceText;

    [Header("Events")]
    public static Action<int> onSkinSelected;


    private void Awake()
    {
        priceText.text = skinPrice.ToString();
        UnlockSkin(0);
    }
    // Start is called before the first frame update
    IEnumerator Start()
    {
        ConfigureButtons();
        UpdatePurchaseButton();
        
        yield return null; //wait a frame
        SelectSkin(GetLastSelectedSkin());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            UnlockSkin(Random.Range(0, skinButtons.Length));
        if(Input.GetKeyDown(KeyCode.D))
            PlayerPrefs.DeleteAll();
    }
    public void ConfigureButtons()
    {
        //configure all buttons
        for (int i = 0; i < skinButtons.Length; i++)
        {
            bool unlocked = PlayerPrefs.GetInt("skinButton"+i) == 1;
            skinButtons[i].Configure(skins[i], unlocked);
            int skinIndex = i;
            skinButtons[i].GetButton().onClick.AddListener(() => SelectSkin(skinIndex)); //lambda action, learn
        }
    }
    public void UnlockSkin(int skinIndex)
    {
        PlayerPrefs.SetInt("skinButton" + skinIndex,1);
        skinButtons[skinIndex].Unlock();
    }
    private void UnlockSkin(SkinButton skinButton)
    {
        int skinIndex = skinButton.transform.GetSiblingIndex();
        UnlockSkin(skinIndex);
    }

    private void SelectSkin(int skinIndex) //select a skin with index
    {
        //Debug.Log("Skin" + skinIndex + "has been selected");

        for (int i = 0; i < skinButtons.Length; i++)
        {
            if(skinIndex == i)
            {
                skinButtons[i].Select();
            }
            else
            {
                skinButtons[i].DeSelect();
            }
           
        }
        onSkinSelected?.Invoke(skinIndex);
        SaveLastSelectedSkin(skinIndex);

    }
    public void PurchaseSkin()
    {
        List<SkinButton> skinButtonsList = new List<SkinButton>();

        for (int i = 0; i < skinButtons.Length; i++)
        {
            if (!skinButtons[i].IsUnlocked())
                skinButtonsList.Add(skinButtons[i]);
        }
        if (skinButtonsList.Count <= 0)
            return;
            //we will still have some locked skins
            // we have a list of all of them
        SkinButton randomSkinButton = skinButtonsList[Random.Range(0, skinButtonsList.Count)];
        UnlockSkin(randomSkinButton);
        SelectSkin(randomSkinButton.transform.GetSiblingIndex());

        DataManager.instance.UseCoins(skinPrice);
        UpdatePurchaseButton();
        
    }public void UpdatePurchaseButton()
    {
        if (DataManager.instance.GetCoins() < skinPrice)
        {
            purchaseButton.interactable = false;
        }
        else
        {
            purchaseButton.interactable = true;
        }
    }
    private int GetLastSelectedSkin()
    {
        return PlayerPrefs.GetInt("lastSelectedSkin", 0);
    }
    private void SaveLastSelectedSkin(int skinIndex)
    {
        PlayerPrefs.SetInt("lastSelectedSkin", skinIndex);
    }
}
