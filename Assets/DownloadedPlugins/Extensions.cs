using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    
    /// <summary>
    /// Remaps a given floating-point number from one range to another. Does not check for NaN errors.
    /// <br></br>
    /// <br></br>
    /// Example: 3, 0, 10, 0, 1   returns 0.3
    /// <br></br>
    /// Example: 3, 0, 1, 0, 10   returns 30
    /// <br></br>
    /// Example: 3, 0, 0, 0, 10   returns NaN
    /// </summary>
    /// <param name="value">A number to remap</param>
    /// <param name="oldStart">Start of old range</param>
    /// <param name="oldEnd">End of old range</param>
    /// <param name="newStart">Start of new range</param>
    /// <param name="newEnd">End of new range</param>
    /// <returns>A remapped floating-point number</returns>
    public static float Remap (this float value, float oldStart, float oldEnd, float newStart, float newEnd) 
    {
        return (value - oldStart) / (oldEnd - oldStart) * (newEnd - newStart) + newStart;
    }    
    
    /// <summary>
    /// Remaps a given integer from one range to another. Does not check for NaN errors.
    /// <br></br>
    /// <br></br>
    /// Example: 3, 0, 10, 0, 1   returns 0
    /// <br></br>
    /// Example: 3, 0, 1, 0, 10   returns 30
    /// <br></br>
    /// Example: 3, 0, 0, 0, 10   returns NaN
    /// </summary>
    /// <param name="value">A number to remap</param>
    /// <param name="oldStart">Start of old range</param>
    /// <param name="oldEnd">End of old range</param>
    /// <param name="newStart">Start of new range</param>
    /// <param name="newEnd">End of new range</param>
    /// <returns>A remapped and rounded integer number</returns>
    public static int Remap (this int value, int oldStart, int oldEnd, int newStart, int newEnd)
    {
        return Mathf.RoundToInt(((float)value).Remap(oldStart, oldEnd, newStart, newEnd));
    }

    
    /// <summary>
    /// Randomizes and clamps the value with given +-amount
    /// </summary>
    /// <param name="value">Given float number</param>
    /// <param name="amount">Amount to randomize. Random(-amount, amount)</param>
    /// <param name="minClamp">Lower bound of a number after randomization (default is float.MinValue)</param>
    /// <param name="maxClamp">Upper bound of a number after randomization (default is float.MaxValue)</param>
    /// <returns></returns>
    public static float Randomize(this float value, float amount, float minClamp = float.MinValue, float maxClamp = float.MaxValue)
    {
        float random = UnityEngine.Random.Range(-amount, amount);
        value = Mathf.Clamp(value + random, minClamp, maxClamp);
        return value;
    }   
    
    /// <summary>
    /// Randomizes and clamps the value with given +-amount
    /// </summary>
    /// <param name="value">Given int number</param>
    /// <param name="amount">Amount to randomize. Random(-amount, amount) (both inclusive)</param>
    /// <param name="minClamp">Lower bound of a number after randomization (default is float.MinValue)</param>
    /// <param name="maxClamp">Upper bound of a number after randomization (default is float.MaxValue)</param>
    /// <returns></returns>
    public static int Randomize(this int value, int amount, int minClamp = int.MinValue, int maxClamp = int.MaxValue)
    {
        int random = UnityEngine.Random.Range(-amount, amount + 1);
        value = Mathf.Clamp(value + random, minClamp, maxClamp);
        return value;
    }
    
    public static T GetRandom<T>(this List<T> list)
    {
        if (list != null && list.Count > 0)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }
        else
        {
            return default;
        }
    }
    
}

