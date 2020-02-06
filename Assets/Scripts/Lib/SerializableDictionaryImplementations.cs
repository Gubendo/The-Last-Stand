using System;
 
using UnityEngine;
 
// ---------------
//  String => Int
// ---------------
[Serializable]
public class StringIntDictionary : SerializableDictionary<string, int> {}
 
// ---------------
//  GameObject => Float
// ---------------
[Serializable]
public class GameObjectFloatDictionary : SerializableDictionary<GameObject, float> {}



//------------
// String --> GameObject
// 

[Serializable]
public class StringTextureDictionary : SerializableDictionary<String,Texture>{}

[Serializable]
public class IntGameObjectDictionary : SerializableDictionary<int,GameObject>{}
