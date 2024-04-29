using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CAMERAsMASH : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.activeSelf)
        {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #endif
        }
    }
}
