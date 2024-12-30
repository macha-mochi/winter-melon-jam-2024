using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeverEndingSong : MonoBehaviour
{
    [SerializeField] private GameObject music;
    private void Awake()
    {
        DontDestroyOnLoad(music);
    }
}
