using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;

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
        double cumulative = 0.0;
        for (int i = 0; i < elementsWithProbabilities.Count; i++)
        {
            cumulative += elementsWithProbabilities[i].Value;
            if (dice100 <= cumulative)
            {
                return (T)Convert.ChangeType(elementsWithProbabilities[i].Key, typeof(T));
            }
        }

        return default(T);
    }

    public static string descriptionBuilder(CardDatabaseStructure.ICardInfoInterface card)
    {
        IEnumerable<int> variableLocationsInString = card.description.AllIndexesOf("{");

        List<string> attributes = card.description.BetweenAll("{", "}");

        foreach (string attribute in attributes)
        {
            if (!(attribute.Count(s => s == '{') >= 2 && attribute.Count(s => s == '{') != 0) )
            {
                string attribute_ = attribute.Substring(1, attribute.Length - 2);
                card.description = card.description.Replace('{' + attribute_ + '}', GetPropertyValue(card.attributes, attribute_).ToString());

            }
        }

        return card.description;
    }
    public static Sprite ImageFromUrl(string url)
    {
        WWW www = new WWW(Application.streamingAssetsPath + url);
        Sprite sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
        return sprite;
    }

    public static object GetPropertyValue(object srcobj, string propertyName)
    {
        if (srcobj == null)
            return null;

        object obj = srcobj;

        // Split property name to parts (propertyName could be hierarchical, like obj.subobj.subobj.property
        string[] propertyNameParts = propertyName.Split('.');

        foreach (string propertyNamePart in propertyNameParts)
        {
            if (obj == null) return null;

            // propertyNamePart could contain reference to specific 
            // element (by index) inside a collection
            if (!propertyNamePart.Contains("["))
            {
                PropertyInfo pi = obj.GetType().GetProperty(propertyNamePart);
                if (pi == null) return null;
                obj = pi.GetValue(obj, null);
            }
            else
            {   // propertyNamePart is areference to specific element 
                // (by index) inside a collection
                // like AggregatedCollection[123]
                //   get collection name and element index
                int indexStart = propertyNamePart.IndexOf("[") + 1;
                string collectionPropertyName = propertyNamePart.Substring(0, indexStart - 1);
                int collectionElementIndex = Int32.Parse(propertyNamePart.Substring(indexStart, propertyNamePart.Length - indexStart - 1));
                //   get collection object
                PropertyInfo pi = obj.GetType().GetProperty(collectionPropertyName);
                if (pi == null) return null;
                object unknownCollection = pi.GetValue(obj, null);
                //   try to process the collection as array
                if (unknownCollection.GetType().IsArray)
                {
                    object[] collectionAsArray = unknownCollection as object[];
                    obj = collectionAsArray[collectionElementIndex];
                }
                else
                {
                    //   try to process the collection as IList
                    System.Collections.IList collectionAsList = unknownCollection as System.Collections.IList;
                    if (collectionAsList != null)
                    {
                        obj = collectionAsList[collectionElementIndex];
                    }
                    else
                    {
                        // ??? Unsupported collection type
                    }
                }
            }
        }

        return obj;
    }
}
