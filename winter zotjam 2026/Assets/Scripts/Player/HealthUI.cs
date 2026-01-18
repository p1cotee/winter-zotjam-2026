using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject _heart1;
    [SerializeField] private GameObject _heart2;

    public static HealthUI Instance { get; private set; }//rushing this, this is singleton now lol

    void Awake()//singleton pattern
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        Debug.Log("HealthUI singleton initialized");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _heart1.SetActive(true);
        _heart2.SetActive(true);
    }

    public void UpdateHealth(int currentHP)
    {
        switch (currentHP)
        {
            case 2:
                _heart1.SetActive(true);
                _heart2.SetActive(true);
                break;
            case 1:
                _heart1.SetActive(true);
                _heart2.SetActive(false);
                break;
            case 0:
                _heart1.SetActive(false);
                _heart2.SetActive(false);
                break;
            default:
                Debug.LogWarning("Invalid HP value: " + currentHP);
                break;
        }
    }

}
