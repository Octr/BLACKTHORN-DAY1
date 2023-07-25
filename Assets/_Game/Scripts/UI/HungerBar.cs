using UnityEngine;

/// <summary>
/// Script for managing a Hunger Bar that constantly ticks down and can be increased by a value with a smooth animation.
/// When the gauge reaches 0, it triggers the "Game Over" logic, but the player has a chance to keep increasing it to avoid the game over state.
/// </summary>
public class HungerBar : MonoBehaviour
{
    [SerializeField] private float maxValue = 100f;
    [SerializeField] private float currentValue = 100f;
    [SerializeField] private float tickRate = 1f; // How much the gauge decreases per second
    [SerializeField] private float increaseSpeed = 10f; // Speed at which the gauge increases

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

            if (currentValue <= 0f)
            {
                // Game over logic here
                Debug.Log("Game Over");
            }
        }
        else
        {
            // Increase the gauge value smoothly
            if (currentValue < targetValue)
            {
                currentTimer += Time.deltaTime;
                currentValue = Mathf.Lerp(currentValue, targetValue, currentTimer / increaseSpeed);
            }
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
        isPaused = true;
        targetValue = Mathf.Clamp(targetValue + value, 0f, maxValue);
        currentTimer = 0f;
        isPaused = false;
    }
}
