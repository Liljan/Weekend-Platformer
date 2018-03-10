using System;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    private static PlayerEvents instance;

    // Player events
    public event Action<Transform> SpawnPlayer;
    public event Action DespawnPlayer;

    public event Action<Transform, float> TouchPlatform;
    
    public event Action<int> TakeDamage;

    public event Action<Vector3, Quaternion> SpawnShot;
    public event Action<GameObject> DespawnShot;
 
    private void Awake()
    {
        instance = this;
    }
    
    public static PlayerEvents Instance()
    {
        return instance;
    }

    public void InvokeTouchPlatform(Transform trans, float offset)
    {
        TouchPlatform.Invoke(trans, offset);
    }

    public void InvokeSpawnPlayer(Transform t)
    {
        SpawnPlayer.Invoke(t);
    }

    public void InvokeDeath()
    {
        DespawnPlayer.Invoke();
    }

    public void InvokeTakeDamage(int i)
    {
        TakeDamage.Invoke(i);
    }

    public void InvokeSpawnShot(Vector3 pos, Quaternion rot)
    {
        SpawnShot.Invoke(pos, rot);
    }

    public void InvokeDespawnShot(GameObject g)
    {
        DespawnShot.Invoke(g);
    }

}
