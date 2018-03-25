using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour {

    public FillBar playerHealthBar;

    void Start()
    {
        // Register listeners
        PlayerEvents.Instance().UpdateHealth += UpdateHealth;
    }

    public void UpdateHealth(int h, int max)
    {
        playerHealthBar.SetFill((float)h / max);
    }
}
