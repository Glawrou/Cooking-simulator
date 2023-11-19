using UnityEngine;

public static class JsonReader
{
    public static T Read<T>(string nameFile)
    {
        return JsonUtility.FromJson<T>(Resources.Load<TextAsset>("IngredientsScoreData").ToString());
    }
}
