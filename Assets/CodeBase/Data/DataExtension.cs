﻿using UnityEngine;

namespace Assets.CodeBase.Data
{
    public static class DataExtension
    {
        public static string ToJson(this object obj) =>
            JsonUtility.ToJson(obj);

        public static T ToDeserialized<T>(this string json) =>
            JsonUtility.FromJson<T>(json);
    }
}
