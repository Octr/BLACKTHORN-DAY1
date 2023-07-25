using UnityEngine;
using UnityEngine.UI;

public class HungerBar : Singleton<HungerBar>
{
    [SerializeField] private float maxValue = 100f;
    [SerializeField] private float currentValue = 100f;
    [SerializeField] private float tickRate = 1f; // How much the gauge decreases per second
    [SerializeField] private float increaseSpeed = 10f; // Speed at which the gauge increases
    [SerializeField] private Image hungerFillImage; // Reference to the UI Image component

    private bool isPaused = false;
    private float targetValue;
    private float currentTimer;

    private void Start()
    {
        targetValue = currentValue;
    }

    private void Update()
    {
        if (!isPaused)
        {
            currentValue -= tickRate * Time.deltaTime;
            currentValue = Mathf.Clamp(currentValue, 0f, maxValue);
            UpdateHungerFillImage();

            if (currentValue <= 0f)
            {
                // Game over logic here
                Debug.Log("Game Over");
            }
        }
    }

    private void UpdateHungerFillImage()
    {
        if (hungerFillImage != null)
        {
            float fillAmount = currentValue / maxValue;
            hungerFillImage.fillAmount = fillAmount;
        }
    }

    /// <summary>
    /// Pauses the Hunger Bar from ticking down.
    /// </summary>
    public void PauseHungerBar()
    {
        isPaused = true;
    }

    /// <summary>
    /// Increases the Hunger Bar value by a specified amount with a smooth animation.
    /// </summary>
    /// <param name="value">The amount to increase the Hunger Bar by.</param>
    public void IncreaseHunger(float value)
    {
        targetValue = Mathf.Clamp(currentValue + value, 0f, maxValue);
        StartCoroutine(IncreaseHungerOverTime());
    }

    private System.Collections.IEnumerator IncreaseHungerOverTime()
    {
        float initialValue = currentValue;
        float timer = 0f;

        while (timer < increaseSpeed)
        {
            timer += Time.deltaTime;
            currentValue = Mathf.Lerp(initialValue, targetValue, timer / increaseSpeed);
            UpdateHungerFillImage();
            yield return null;
        }

        currentValue = targetValue;
        UpdateHungerFillImage();
    }
}
