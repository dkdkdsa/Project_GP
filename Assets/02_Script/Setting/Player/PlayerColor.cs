using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerColor
{
    public static Color HexColor(string hex)
    {
        if (!hex.StartsWith("#"))
        {
            hex = "#" + hex;
        }

        if (ColorUtility.TryParseHtmlString(hex, out var color))
        {
            return color;
        }

        return new Color(1f, 1f, 1f, 1f);
    }

    private static List<Color> colors = new List<Color>();

    static PlayerColor()
    {
        
        colors.Add(HexColor("FF0000")); //red
        colors.Add(HexColor("B300FF")); //purple
        colors.Add(HexColor("0DFF00")); //green
        colors.Add(HexColor("F6FF00")); //yellow
    }

    public static Color GetColor(PlayerColorType type)
    {
        return colors[(int)type];
    }

    public static Color Red => colors[(int)PlayerColorType.Red];
    public static Color Purple => colors[(int)PlayerColorType.Purple];
    public static Color Green => colors[(int)PlayerColorType.Green];
    public static Color Yellow => colors[(int)PlayerColorType.Yellow];
}
