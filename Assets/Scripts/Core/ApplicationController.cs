using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Instantiate and initialize necessary objects.
/// </summary>
public class ApplicationController : SingletonMono<ApplicationController>
{

    [RuntimeInitializeOnLoadMethod]
    static void OnInit()
    {
        Instance.Init();
    }

    #region public
    public void Init()
    {

    }
    #endregion
}