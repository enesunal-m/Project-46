using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains global helper functions
/// </summary>
public static class HelperFunctions
{
    /// <summary>
    /// Returns a randomly selected element of given KeyValuePair list that 
    /// contains the main list and probabilities of elements
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="elementsWithProbabilities"></param>
    /// <returns></returns>
    public static T selectElementWithProbability<T>(List<KeyValuePair<T, float>> elementsWithProbabilities)
    {
        int dice100 = UnityEngine.Random.Range(1, 101);

        System.Random r = new System.Random();
        double diceRoll = r.NextDouble();

        double cumulative = 0.0;
        for (int i = 0; i < elementsWithProbabilities.Count; i++)
        {
            cumulative += elementsWithProbabilities[i].Value;
            if (diceRoll < cumulative)
            {
                return (T)Convert.ChangeType(elementsWithProbabilities[i].Key, typeof(T));
            }
        }

        return default(T);
    }
}
