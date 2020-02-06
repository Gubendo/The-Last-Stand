using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor;
 
// ---------------
//  String => Int
// ---------------
[UnityEditor.CustomPropertyDrawer(typeof(StringIntDictionary))]
public class StringIntDictionaryDrawer : SerializableDictionaryDrawer<string, int> {
    protected override SerializableKeyValueTemplate<string, int> GetTemplate() {
        return GetGenericTemplate<SerializableStringIntTemplate>();
    }
}
internal class SerializableStringIntTemplate : SerializableKeyValueTemplate<string, int> {}
 
// ---------------
//  GameObject => Float
// ---------------
[UnityEditor.CustomPropertyDrawer(typeof(GameObjectFloatDictionary))]
public class GameObjectFloatDictionaryDrawer : SerializableDictionaryDrawer<GameObject, float> {
    protected override SerializableKeyValueTemplate<GameObject, float> GetTemplate() {
        return GetGenericTemplate<SerializableGameObjectFloatTemplate>();
    }
}
internal class SerializableGameObjectFloatTemplate : SerializableKeyValueTemplate<GameObject, float> {}


//--------------------
// String ---> Texture
//------------------
[UnityEditor.CustomPropertyDrawer(typeof(StringTextureDictionary))]
public class StringTextureDrawer : SerializableDictionaryDrawer<String,Texture> {
    protected override SerializableKeyValueTemplate<String, Texture> GetTemplate() {
        return GetGenericTemplate<SerializableStringTextureTemplate>();
    }
}
internal class SerializableStringTextureTemplate : SerializableKeyValueTemplate<String, Texture> {}


//--------------------
// int ---> Texture
//------------------
[UnityEditor.CustomPropertyDrawer(typeof(IntGameObjectDictionary))]
public class IntGameObjectDrawer : SerializableDictionaryDrawer<int,GameObject> {
    protected override SerializableKeyValueTemplate<int, GameObject> GetTemplate() {
        return GetGenericTemplate<SerializableIntGameObjectTemplate>();
    }
}
internal class SerializableIntGameObjectTemplate : SerializableKeyValueTemplate<int, GameObject> {}