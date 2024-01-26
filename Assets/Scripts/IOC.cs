using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New IOC", menuName = "IOC")]
public class IOC : ScriptableObject
{
    private static IOC instance;

    public Difficulty gameDifficulty;

    private Dictionary<Type, object> objectMap = new Dictionary<Type, object>();

    public static IOC Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<IOC>("IOC");

                if (instance == null)
                {
                    Debug.LogError("IOC asset not found! Please create an instance of IOC in the Resources folder.");
                }
                else
                {
                    instance.InitObjectMap();
                }
            }

            return instance;
        }
    }

    private void InitObjectMap()
    {
        objectMap.Clear();
        if (gameDifficulty != null)
        {
            IOC.Register(gameDifficulty);
        }
    }

    public static void Register<T>(T obj) where T : class
    {
        Instance.AddObject(typeof(T), obj);
    }

    public static T Get<T>() where T : class
    {
        return Instance.GetObject(typeof(T)) as T;
    }

    private void AddObject(Type type, object obj)
    {
        if (objectMap.ContainsKey(type))
        {
            Debug.LogError($"Object of type {type.Name} already registered in IOC.");
            return;
        }

        objectMap.Add(type, obj);
    }

    private object GetObject(Type type)
    {
        if (objectMap.ContainsKey(type))
        {
            return objectMap[type];
        }

        Debug.LogError($"Object of type {type.Name} not registered in IOC.");
        return null;
    }
}