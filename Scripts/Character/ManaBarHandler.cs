
using UnityEngine;
using UnityEngine.UI;

public class ManaBarHandler : MonoBehaviour
{
    private static Image HealthBarImage;
    private Player player;
    [SerializeField] private GameObject PlayerObj;
    private float currentMana;
    /// <summary>
    /// Sets the health bar value
    /// </summary>
    /// <param name="value">should be between 0 to 1</param>
    public static void SetHealthBarValue(float value)
    {
        HealthBarImage.fillAmount = value;
    }

    public static float GetHealthBarValue()
    {
        return HealthBarImage.fillAmount;
    }

    /// <summary>
    /// Sets the health bar color
    /// </summary>
    /// <param name="healthColor">Color </param>
    public static void SetHealthBarColor(Color healthColor)
    {
        HealthBarImage.color = healthColor;
    }

    /// <summary>
    /// Initialize the variable
    /// </summary>
    private void Start()
    {
        HealthBarImage = GetComponent<Image>();
        player = PlayerObj.GetComponent<Player>();

    }
    private void Update()
    {
        currentMana = player.Mana / 100f;
        SetHealthBarValue(currentMana);
    }
}