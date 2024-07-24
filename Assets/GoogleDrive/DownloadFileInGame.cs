using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DownloadFileInGame : MonoBehaviour
{
    public PlayerScale playerScale;
    private PlayerScaleChange _playerScaleChange;

    void Start()
    {
       _playerScaleChange = FindAnyObjectByType<PlayerScaleChange>();
    }
    public static void LoadData(string filePath, PlayerScaleChange playerScaleChange)
    {
        ShootAbility shootAbility = FindAnyObjectByType<ShootAbility>();
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerScale loadedData = JsonUtility.FromJson<PlayerScale>(json);

            if (loadedData != null)
            {
                Debug.Log("Player data loaded from: " + filePath);

                GameObject player = shootAbility.gameObject; 
                if (player != null)
                {
                    playerScaleChange.ApplyPlayerScale(loadedData);
                }
            }
            else
            {
                Debug.LogError("Failed to load player data from JSON.");
            }
        }
        else
        {
            Debug.LogError("File not found at: " + filePath);
        }
    }
}
