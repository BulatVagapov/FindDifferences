using UnityEngine;
using UnityEngine.Purchasing;

public class PurchaseManager : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;

    public void OnPurchaseComplited(Product product)
    {
        switch (product.definition.id)
        {
            case "FindDiffereces.10sec":
                Add10seconds();
                break;
        }
    }

    public void OnPurchaseFailed()
    {
        OnEndPurchase();
    }
    
    public void Add10seconds()
    {
        levelManager.Timer.IncreaseTime(10);
        OnEndPurchase();
    }

    public void OnStartPurchase()
    {
        Time.timeScale = 0;
    }

    public void OnEndPurchase()
    {
        Time.timeScale = 1;
    }

}
