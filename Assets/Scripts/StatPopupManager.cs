using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatPopupManager : MonoBehaviour
{
    public List<RPG.HeroData> heroList;
    public GameObject statPanel;
    [SerializeField]
    private Button closeButton;
    [SerializeField]
    private FillHeroStats heroStats;
    void Start()
    {

    }

    private void OnEnable()
    {
        EventManager.DisplayHeroStats.AddListener(GetHeroData);
        closeButton.onClick.AddListener(ClosePopup);
    }

    private void OnDisable()
    {
        EventManager.DisplayHeroStats.RemoveListener(GetHeroData);
        closeButton.onClick.RemoveListener(ClosePopup);
    }

    private void ClosePopup()
    {
        statPanel.SetActive(false);
    }


    void GetHeroData(RPG.CharacterData.CharacterName characterName)
    {
        statPanel.SetActive(true);
        foreach (var item in heroList)
        {
            if(item.heroName == characterName)
            {
                heroStats.UpdateStats(item);
                return;
            }
        }
    }

}
