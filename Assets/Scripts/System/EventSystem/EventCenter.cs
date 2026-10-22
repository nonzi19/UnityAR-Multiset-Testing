using System;
using System.Collections.Generic;

public class EventCenter
{
    private static Dictionary<Enum, Delegate> _eventTable = new();

    private static void OnListenerAdd(Enum eventType, Delegate callback)
    {
        if (!_eventTable.ContainsKey(eventType))
        {
            _eventTable.Add(eventType, null);
        }

        Delegate d = _eventTable[eventType];

        if (d != null && d.GetType() != callback.GetType())
        {
            throw new Exception(string.Format("Unable to add listener!", eventType, d.GetType(), callback.GetType()));
        }
    }

    public static void AddListener(Enum eventType, Callback callback)
    {
        OnListenerAdd(eventType, callback);
        _eventTable[eventType] = (Callback)_eventTable[eventType] + callback;
    }

    public static void AddListener<T>(Enum eventType, Callback<T> callback)
    {
        OnListenerAdd(eventType, callback);
        _eventTable[eventType] = (Callback<T>)_eventTable[eventType] + callback;
    }

    public static void AddListener<T, U>(Enum eventType, Callback<T, U> callback)
    {
        OnListenerAdd(eventType, callback);
        _eventTable[eventType] = (Callback<T, U>)_eventTable[eventType] + callback;
    }

    public static void AddListener<T, U, V>(Enum eventType, Callback<T, U, V> callback)
    {
        OnListenerAdd(eventType, callback);
        _eventTable[eventType] = (Callback<T, U, V>)_eventTable[eventType] + callback;
    }

    public static void AddListener<T, U, V, W>(Enum eventType, Callback<T, U, V, W> callback)
    {
        OnListenerAdd(eventType, callback);
        _eventTable[eventType] = (Callback<T, U, V, W>)_eventTable[eventType] + callback;
    }

    public static void AddListener<T, U, V, W, X>(Enum eventType, Callback<T, U, V, W, X> callback)
    {
        OnListenerAdd(eventType, callback);
        _eventTable[eventType] = (Callback<T, U, V, W, X>)_eventTable[eventType] + callback;
    }

    public static void AddListener<T, U, V, W, X, Y>(Enum eventType, Callback<T, U, V, W, X, Y> callback)
    {
        OnListenerAdd(eventType, callback);
        _eventTable[eventType] = (Callback<T, U, V, W, X, Y>)_eventTable[eventType] + callback;
    }

    public static void AddListener<T, U, V, W, X, Y, Z>(Enum eventType, Callback<T, U, V, W, X, Y, Z> callback)
    {
        OnListenerAdd(eventType, callback);
        _eventTable[eventType] = (Callback<T, U, V, W, X, Y, Z>)_eventTable[eventType] + callback;
    }

    private static void OnListenerRemove(Enum eventType, Delegate callback)
    {
        if (_eventTable.ContainsKey(eventType))
        {
            Delegate d = _eventTable[eventType];

            if (d == null)
            {
                throw new Exception(string.Format("Unable to remove listener!", eventType));
            }
            else if (d.GetType() != callback.GetType())
            {
                throw new Exception(string.Format("Unable to remove listener!", eventType, d.GetType(), callback.GetType()));
            }
        }
        else
        {
            throw new Exception(string.Format("Unable to remove listener!", eventType));
        }
    }

    private static void OnListenerRemoved(Enum eventType)
    {
        if (_eventTable[eventType] == null)
        {
            _eventTable.Remove(eventType);
        }
    }

    public static void RemoveListener(Enum eventType, Callback callback)
    {
        OnListenerRemove(eventType, callback);
        _eventTable[eventType] = (Callback)_eventTable[eventType] - callback;
        OnListenerRemoved(eventType);
    }

    public static void RemoveListener<T>(Enum eventType, Callback<T> callback)
    {
        OnListenerRemove(eventType, callback);
        _eventTable[eventType] = (Callback<T>)_eventTable[eventType] - callback;
        OnListenerRemoved(eventType);
    }

    public static void RemoveListener<T, U>(Enum eventType, Callback<T, U> callback)
    {
        OnListenerRemove(eventType, callback);
        _eventTable[eventType] = (Callback<T, U>)_eventTable[eventType] - callback;
        OnListenerRemoved(eventType);
    }

    public static void RemoveListener<T, U, V>(Enum eventType, Callback<T, U, V> callback)
    {
        OnListenerRemove(eventType, callback);
        _eventTable[eventType] = (Callback<T, U, V>)_eventTable[eventType] - callback;
        OnListenerRemoved(eventType);
    }

    public static void RemoveListener<T, U, V, W>(Enum eventType, Callback<T, U, V, W> callback)
    {
        OnListenerRemove(eventType, callback);
        _eventTable[eventType] = (Callback<T, U, V, W>)_eventTable[eventType] - callback;
        OnListenerRemoved(eventType);
    }

    public static void RemoveListener<T, U, V, W, X>(Enum eventType, Callback<T, U, V, W, X> callback)
    {
        OnListenerRemove(eventType, callback);
        _eventTable[eventType] = (Callback<T, U, V, W, X>)_eventTable[eventType] - callback;
        OnListenerRemoved(eventType);
    }

    public static void RemoveListener<T, U, V, W, X, Y>(Enum eventType, Callback<T, U, V, W, X, Y> callback)
    {
        OnListenerRemove(eventType, callback);
        _eventTable[eventType] = (Callback<T, U, V, W, X, Y>)_eventTable[eventType] - callback;
        OnListenerRemoved(eventType);
    }

    public static void RemoveListener<T, U, V, W, X, Y, Z>(Enum eventType, Callback<T, U, V, W, X, Y, Z> callback)
    {
        OnListenerRemove(eventType, callback);
        _eventTable[eventType] = (Callback<T, U, V, W, X, Y, Z>)_eventTable[eventType] - callback;
        OnListenerRemoved(eventType);
    }

    public static void Broadcast(Enum eventType)
    {
        if (_eventTable.TryGetValue(eventType, out Delegate d))
        {
            (d as Callback)?.Invoke();
        }
    }

    public static void Broadcast<T>(Enum eventType, T arg)
    {
        if (_eventTable.TryGetValue(eventType, out Delegate d))
        {
            (d as Callback<T>)?.Invoke(arg);
        }
    }

    public static void Broadcast<T, U>(Enum eventType, T arg1, U arg2)
    {
        if (_eventTable.TryGetValue(eventType, out Delegate d))
        {
            (d as Callback<T, U>)?.Invoke(arg1, arg2);
        }
    }

    public static void Broadcast<T, U, V>(Enum eventType, T arg1, U arg2, V arg3)
    {
        if (_eventTable.TryGetValue(eventType, out Delegate d))
        {
            (d as Callback<T, U, V>)?.Invoke(arg1, arg2, arg3);
        }
    }

    public static void Broadcast<T, U, V, W>(Enum eventType, T arg1, U arg2, V arg3, W arg4)
    {
        if (_eventTable.TryGetValue(eventType, out Delegate d))
        {
            (d as Callback<T, U, V, W>)?.Invoke(arg1, arg2, arg3, arg4);
        }
    }

    public static void Broadcast<T, U, V, W, X>(Enum eventType, T arg1, U arg2, V arg3, W arg4, X arg5)
    {
        if (_eventTable.TryGetValue(eventType, out Delegate d))
        {
            (d as Callback<T, U, V, W, X>)?.Invoke(arg1, arg2, arg3, arg4, arg5);
        }
    }

    public static void Broadcast<T, U, V, W, X, Y>(Enum eventType, T arg1, U arg2, V arg3, W arg4, X arg5, Y arg6)
    {
        if (_eventTable.TryGetValue(eventType, out Delegate d))
        {
            (d as Callback<T, U, V, W, X, Y>)?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
        }
    }

    public static void Broadcast<T, U, V, W, X, Y, Z>(Enum eventType, T arg1, U arg2, V arg3, W arg4, X arg5, Y arg6, Z arg7)
    {
        if (_eventTable.TryGetValue(eventType, out Delegate d))
        {
            (d as Callback<T, U, V, W, X, Y, Z>)?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }
    }
}
