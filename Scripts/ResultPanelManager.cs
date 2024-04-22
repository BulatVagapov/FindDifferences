using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanelManager : MonoBehaviour
{
    [SerializeField] private Button resultButton;
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private TMP_Text resultText;

    [SerializeField] private LevelManager levelManager;
    
    public void Win()
    {
        resultText.text = "you win";
        buttonText.text = "next level";
        gameObject.SetActive(true);
    }

    public void Loose()
    {
        resultText.text = "you losse";
        buttonText.text = "restart";
        gameObject.SetActive(true);
    }

    void Start()
    {
        levelManager.Win += Win;
        levelManager.Loose += Loose;
        gameObject.SetActive(false);
    }
}
