using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;

    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Already Inventory exist in the Scene");
            return;
        }

        instance = this;
    }

    public void addCoins(int amount)
    {
        coinsCount += amount;
        coinsCountText.text = coinsCount.ToString();
    }
}
