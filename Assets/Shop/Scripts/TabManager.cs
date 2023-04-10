using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TabManager : MonoBehaviour
{
    public List<GameObject> tabs = new List<GameObject>();
    public List<TabButton> tabButtons = new List<TabButton>();
    public GameObject tabButtonParent;


    public void SelectTab(int tabIndex)
    {
        ShopManager.instance.ShowPurchaseButtons(false);
        DisableAllTabs();
        tabs[tabIndex].gameObject.SetActive(true);
        tabButtons[tabIndex].SeletcTabButtonVisually();

        TabManager selectedTab = tabs[tabIndex].GetComponent<TabManager>();

        if (selectedTab)
        {
            if (selectedTab.tabButtonParent)
            {
                selectedTab.tabButtonParent.SetActive(true);
            }
            selectedTab.SelectTab(0);
        }


    }

    void DisableAllTabs()
    {
        foreach (GameObject tab in tabs)
        {
            tab.gameObject.SetActive(false);

            TabManager tabManager = tab.GetComponent<TabManager>();
            if (tabManager)
            {
                if (tabManager.tabButtonParent)
                {
                    tabManager.tabButtonParent.SetActive(false);
                }
            }
        }
        foreach (TabButton tabButton in tabButtons)
        {
            tabButton.DeseletTabVisually();
        }

    }
}