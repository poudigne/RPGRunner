using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum ResourcesType
{
    Woods,
    Rocks,
    Coins
}

public class ResourcesManager : MonoBehaviour
{

    public Text coinValueUI;
    public Text woodValueUI;
    public Text rockValueUI;

    public void Start()
    {
        UpdateUI();
    }

    public void AddResources(ResourcesType type, int qty)
    {
        PlayerPrefs.SetInt(type.ToString(), PlayerPrefs.GetInt(type.ToString()) + qty);
        UpdateUI();
    }

    void UpdateUI()
    {
        coinValueUI.text = GetResourcesQty(ResourcesType.Coins).ToString();
        rockValueUI.text = GetResourcesQty(ResourcesType.Rocks).ToString();
        woodValueUI.text = GetResourcesQty(ResourcesType.Woods).ToString();
    }


    public int GetResourcesQty(ResourcesType type)
    {
        return PlayerPrefs.GetInt(type.ToString());
    }
}
