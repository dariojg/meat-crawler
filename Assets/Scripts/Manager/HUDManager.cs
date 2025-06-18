
using UnityEngine;

using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

    public static HUDManager Instance { get; private set; }    public Image healthFill;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    float maxHealth = 1f;
    private float currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    public void TakeDamage(float health, float damage)
    {   
        Debug.Log("Take Damage: " + damage);
        currentHealth = Mathf.Clamp(currentHealth - damage, 0f, maxHealth);
        UpdateUI();
    }

    void UpdateUI()
    {
        if (healthFill != null){
            healthFill.fillAmount = currentHealth / maxHealth;
        }
    }

}