using System;
using System.Collections.Generic;
using UnityEngine;
public class StateManager : MonoBehaviour
{
    [SerializeField] private BaseState initialState;
    public BaseState currentState;
    private Dictionary<Type, Component> cachedComponents;

    private float actionInterval = 0.5f;
    private float nextActionTime = 0f;
    private void Awake()
    {
        currentState = initialState;
        cachedComponents = new Dictionary<Type, Component>();
    }

    private void Update()
    {
        if (Time.time >= nextActionTime)
        {
            currentState.Execute(this);
            nextActionTime = Time.time + actionInterval;
        }
    }

    public new T GetComponent<T>() where T : Component
    {
        if (cachedComponents.ContainsKey(typeof(T)))
            return cachedComponents[typeof(T)] as T;

        var component = base.GetComponent<T>();
        if (component != null)
            cachedComponents.Add(typeof(T), component);
        
        return component;
    }
}