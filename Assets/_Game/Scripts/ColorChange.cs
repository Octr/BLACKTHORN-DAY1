using UnityEngine;

/// <summary>
/// Lerps the material color between two colors based on a custom function.
/// </summary>
public class ColorChange : MonoBehaviour
{
    [SerializeField] private Renderer goRenderer;
    [SerializeField] private Color targetColor;
    [SerializeField] private Color startColor;
    [SerializeField] private float transitionSpeed = 1.0f;
    [SerializeField] private ColorTag colorTag;

    private Color currentColor;
    private bool isLerping;

    private void Start()
    {
        currentColor = goRenderer.material.color;
    }

    private void Update()
    {
        if (isLerping)
        {
            LerpMaterialColor();
        }
    }

    public void StartColorTransition()
    {
        // Get the color to transition to based on the color type
        targetColor = GetRandomColor();

        // Set the color transition starting point as the current material color
        startColor = goRenderer.material.color;

        // Start the lerping process
        isLerping = true;
    }

    public void LeftColorTransition()
    {
        int activeColor = ((int)colorTag.color);
        int nextColor = ++activeColor;

        var tempColor = GetSpecificColorType(nextColor);

        // Get the color to transition to based on the color type
        targetColor = GetSpecificColor(tempColor);

        // Set the color transition starting point as the current material color
        startColor = goRenderer.material.color;

        // Start the lerping process
        isLerping = true;
    }

    public void RightColorTransition()
    {
        int activeColor = ((int)colorTag.color);
        int nextColor = --activeColor;

        var tempColor = GetSpecificColorType(nextColor);

        // Get the color to transition to based on the color type
        targetColor = GetSpecificColor(tempColor);

        // Set the color transition starting point as the current material color
        startColor = goRenderer.material.color;

        // Start the lerping process
        isLerping = true;
    }

    private void LerpMaterialColor()
    {
        // Calculate the new color to be applied in this frame
        currentColor = Color.Lerp(currentColor, targetColor, transitionSpeed * Time.deltaTime);

        // Apply the new color to the material
        goRenderer.material.color = currentColor;

        // Check if the transition is complete
        if (Vector4.Distance(currentColor, targetColor) < 0.01f)
        {
            isLerping = false;
        }
    }

    private Color GetRandomColor()
    {
        ColorType colorType = GetRandomColorType();
        colorTag.SetColorType(colorType); // Update the ColorTag

        // Define colors for different ColorType values using a switch statement
        switch (colorType)
        {
            case ColorType.WHITE:
                return Color.white;
            case ColorType.BLACK:
                return Color.black;
            case ColorType.RED:
                return Color.red;
            case ColorType.GREEN:
                return Color.green;
            case ColorType.BLUE:
                return Color.blue;
            case ColorType.YELLOW:
                return Color.yellow;
            // Add more cases for other colors as needed
            default:
                return Color.white; // Default to white if an unsupported enum value is provided
        }
    }

    private Color GetSpecificColor(ColorType colorType)
    {
        colorTag.SetColorType(colorType); // Update the ColorTag

        // Define colors for different ColorType values using a switch statement
        switch (colorType)
        {
            case ColorType.WHITE:
                return Color.white;
            case ColorType.BLACK:
                return Color.black;
            case ColorType.RED:
                return Color.red;
            case ColorType.GREEN:
                return Color.green;
            case ColorType.BLUE:
                return Color.blue;
            case ColorType.YELLOW:
                return Color.yellow;
            // Add more cases for other colors as needed
            default:
                return Color.white; // Default to white if an unsupported enum value is provided
        }
    }

    private ColorType GetRandomColorType()
    {
        ColorType[] colorTypes = (ColorType[])System.Enum.GetValues(typeof(ColorType));
        int randomIndex = Random.Range(0, colorTypes.Length - 1); // Exclude the MAX value
        return colorTypes[randomIndex];
    }

    private ColorType GetSpecificColorType(int index)
    {
        ColorType[] colorTypes = (ColorType[])System.Enum.GetValues(typeof(ColorType));

        if (index >= colorTypes.Length - 1)
        {
            index = 0;
        }

        if(index < 0)
        {
            index = colorTypes.Length - 2;
        }
        
        return colorTypes[index];
    }
}
