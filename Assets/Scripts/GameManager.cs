using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float CoulumbicConstant = 0.5f;

    private void Awake()
    {
        if(Instance = null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
