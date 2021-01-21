using TMPro;
using UnityEngine;

public class TextColorChange : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Color[] colors;

    public void ChangeColorOnText(int color)
    {
        text.color = colors[color];
    }
}
