using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static  GameManager _instance;
    public static GameManager instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance)
        {
            Destroy(_instance);
        }

        _instance = this;
    }
    #endregion

}
