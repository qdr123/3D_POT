using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Only allow this script to be attached to the object with the healthbar slider:
[RequireComponent(typeof(Slider))]
public class Healthbar : MonoBehaviour {

    // Visible health bar ui:
    private Slider healthbarDisplay;

    [Header("Main Variables:")]
    // Health variable: (default range: 0-100)
    [Tooltip("Health variable: (default range: 0-100)")] public float health = 100;

    // Percentage of how full your health is: (0-100, no decimals)
    private int healthPercentage = 100;

    // Minimum possible heath:
    [Tooltip("Minimum possible heath: (default is 0)")] public float minimumHealth = 0;

    // Maximum possible health:
    [Tooltip("Maximum possible heath: (default is 100)")] public float maximumHealth = 100;

    // If the character has this health or less, consider them having low health:
    [Tooltip("Low health is less than or equal to this:")] public int lowHealth = 33;

    // If the character has between this health and "low health", consider them having medium health:
    // If they have more than this health, consider them having highHealth:
    [Tooltip("High health is greater than or equal to this:")] public int highHealth = 66;

    [Space]

    [Header("Regeneration:")]
    // regenerateHealth'를 체크하면 캐릭터는 'healthPerSecond'비율로 체력 / 초를 재생합니다:
    public bool regenerateHealth;
    public float healthPerSecond;

    [Space]

    [Header("Healthbar Colors:")]
    public Color highHealthColor = new Color(0.35f, 1f, 0.35f);
    public Color mediumHealthColor = new Color(0.9450285f, 1f, 0.4481132f);
    public Color lowHealthColor = new Color(1f, 0.259434f, 0.259434f);

    private void Start()
    {
        // 상태 표시 줄이 아직 지정되지 않은 경우 자동으로 지정됩니다..
        if (healthbarDisplay == null)
        {
            healthbarDisplay = GetComponent<Slider>();
        }

        // Healthbar의 최소 및 최대 상태를 'minimumHealth'및 'maximumHealth'변수와 동일하게 설정하십시오.:
        healthbarDisplay.minValue = minimumHealth;
        healthbarDisplay.maxValue = maximumHealth;

        // 시작 가시 상태를 변수와 동일하게 변경하십시오.
        UpdateHealth();
    }

    // Every frame:
    private void Update()
    {
        healthPercentage = int.Parse((Mathf.Round(maximumHealth * (health / 100f))).ToString());

        // 플레이어의 체력이 최소 체력보다 낮 으면 체력을 최소 체력으로 설정합니다.:
        if (health < minimumHealth)
        {
            health = minimumHealth;
        }

        // 플레이어의 체력이 최대 체력보다 높으면 최대 체력으로 설정하십시오.
        if (health > maximumHealth)
        {
            health = maximumHealth;
        }

        // 캐릭터의 체력이 가득 차 있지 않고 체력 재생 버튼이 틱되면 'healthPerSecond'비율로 체력 / 초를 재생성합니다
        {
            health += healthPerSecond * Time.deltaTime;

            //상태가 변경 될 때마다 다음과 같이 시각적으로 업데이트하십시오.
            UpdateHealth();
        }
    }

    // 상태 표시 줄을 설정하여 상태 변수와 동일한 상태 값을 표시하십시오.:
    public void UpdateHealth()
    {
        // 플레이어의 체력에 따라 체력 막대 색상 변경:
        if (healthPercentage <= lowHealth && health >= minimumHealth && transform.Find("Bar").GetComponent<Image>().color != lowHealthColor)
        {
            ChangeHealthbarColor(lowHealthColor);
        }
        else if (healthPercentage <= highHealth && health > lowHealth)
        {
            float lerpedColorValue = (float.Parse(healthPercentage.ToString()) - 25) / 41;
            ChangeHealthbarColor(Color.Lerp(lowHealthColor, mediumHealthColor, lerpedColorValue));
        }
        else if (healthPercentage > highHealth && health <= maximumHealth)
        {
            float lerpedColorValue = (float.Parse(healthPercentage.ToString()) - 67) / 33;
            ChangeHealthbarColor(Color.Lerp(mediumHealthColor, highHealthColor, lerpedColorValue));
        }

        healthbarDisplay.value = health;
    }

    public void GainHealth(float amount)
    {
        // '금액'히트 포인트를 추가 한 다음 캐릭터 상태를 업데이트하십시오.:
        health += amount;
        UpdateHealth();
    }

    public void TakeDamage(int amount)
    {
        // 금액'체력을 제거하고 캐릭터 체력을 업데이트하십시오:
        health -= float.Parse(amount.ToString());
        UpdateHealth();
    }

    public void ChangeHealthbarColor(Color colorToChangeTo)
    {
        transform.Find("Bar").GetComponent<Image>().color = colorToChangeTo;
    }

    public void ToggleRegeneration()
    {
        regenerateHealth = !regenerateHealth;
    }

    public void SetHealth(float value)
    {
        health = value;
        UpdateHealth();
    }
}