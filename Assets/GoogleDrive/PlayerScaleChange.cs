using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerScaleChange : MonoBehaviour
{
    public ShootAbility shootAbility;

    void Start()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "playerData.json");
        string json = JsonUtility.ToJson(shootAbility.playerScale, true);

        try
        {
            File.WriteAllText(filePath, json);
            Debug.Log("Player data saved to: " + filePath);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to write file: " + e.Message);
        }
    }
    public  void ApplyPlayerScale(PlayerScale playerScale)
    {
        Debug.Log("Player scale applied: " + playerScale.playerScale);

        PlayerScaleChange playerScaleChange = FindObjectOfType<PlayerScaleChange>();
        GameObject player = playerScaleChange.gameObject;  

        if (player != null)
        {
            player.transform.localScale = Vector3.one * playerScale.playerScale;
            Debug.Log("Player scale changed to: " + player.transform.localScale);
        }
        else
        {
            Debug.LogError("Player object not found.");
        }
    }


}


