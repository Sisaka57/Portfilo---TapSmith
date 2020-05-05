using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager i;

    public PlayerData Data;

    private void Awake()
    {
        i = this;
    }
}
