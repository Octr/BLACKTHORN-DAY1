using UnityEngine;
/// <summary>
/// Simply allows us to tag things with specific colors and check what they are, we can also update the color tag with this simple public method.
/// </summary>
public class ColorTag : MonoBehaviour
{
    public ColorType color;

    public void SetColorType(ColorType colorType)
    {
        color = colorType;
    }
}
