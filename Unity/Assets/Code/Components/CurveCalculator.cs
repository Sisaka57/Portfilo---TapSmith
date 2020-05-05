using System;
using UnityEngine;
using UnityEngine.Math;

[ExecuteInEditMode]
public class CurveCalculator : MonoBehaviour
{
    public AnimationCurve ProgressCurve;

    public Range TapRange;
    public Range LevelRange;
    public int CurrentLevel;

    public int TapsRequired = 0;

    public void Update()
    {
        TapsRequired = Mathf.RoundToInt(ProgressCurve.Evaluate((float)Mathf.Clamp(CurrentLevel, LevelRange.Min, LevelRange.Max) / (float)LevelRange.Max) * TapRange.Max);
    }
}
