using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadFileFromDisk : MonoBehaviour
{
    public string fileUrl = "https://drive.google.com/uc?export=download&id=1Id6auucrKPyDXNGYUaPrwxDahmKEt_Qn";
    public string localFileName = "playerData.json";

    private PlayerScaleChange _playerScaleChange;

    void Start()
    {
        StartCoroutine(DownloadFile());
        _playerScaleChange = FindAnyObjectByType<PlayerScaleChange>();

    }

    IEnumerator DownloadFile()
    {
        string filePath = Path.Combine(Application.persistentDataPath, localFileName);

        using (UnityWebRequest webRequest = UnityWebRequest.Get(fileUrl))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                File.WriteAllBytes(filePath, webRequest.downloadHandler.data);
                Debug.Log("File downloaded and saved to: " + filePath);

                DownloadFileInGame.LoadData(filePath, _playerScaleChange);
            }
            else
            {
                Debug.LogError("Failed to download file: " + webRequest.error);
            }
        }
    }
}
