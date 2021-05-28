using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDeterminant : MonoBehaviour
{
    public static ColorDeterminant Instance;

    public Color[] CellColors;

    [Space(5)]
    public Color PointsDarkColor;
    public Color PointsLightColor;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
