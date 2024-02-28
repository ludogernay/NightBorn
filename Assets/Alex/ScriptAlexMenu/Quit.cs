using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Quit : MonoBehaviour
{
    public void QuitterJeu()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #endif
    }

}
    
