using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class LadderBoardManager : MonoBehaviour
{
    [SerializeField] private GameObject[] leaderBoard;
    // Start is called before the first frame update
    void Start()
    { 
        var filePath = Path.Combine(Application.persistentDataPath, "LaddearBoards.json");
        PlayersInfo playersInfo = JsonConvert.DeserializeObject<PlayersInfo>(File.ReadAllText(filePath));
        playersInfo.PlayersInfos = playersInfo.PlayersInfos.OrderByDescending(x => x.Points).ToList();
        for (int i = 0; i < leaderBoard.Length; i++)
        {
            if (i >= playersInfo.PlayersInfos.Count)
            {
                break;
            }
            leaderBoard[i].transform.Find("player").GetComponent<TextMeshProUGUI>().text = playersInfo.PlayersInfos[i].Name;
            leaderBoard[i].transform.Find("points").GetComponent<TextMeshProUGUI>().text = playersInfo.PlayersInfos[i].Points.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
