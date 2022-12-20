using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool end;

    [SerializeField] private TextMeshProUGUI username;
    private GameObject _player;
    [SerializeField] private TMP_InputField userInput;
    [SerializeField] private Button btnConfirm;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Application.persistentDataPath);
        _player = GameObject.FindWithTag("Player");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        end = false;
        btnConfirm.onClick.AddListener(Confirm);
        username.gameObject.SetActive(false);
        userInput.gameObject.SetActive(false);
        btnConfirm.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            EndGame();
        }
    }

    private void Confirm()
    {
        //PlayerInfoClass player = new PlayerInfoClass(userInput.text, 100);
        var filePath = Path.Combine(Application.persistentDataPath, "LaddearBoards.json");
        PlayersInfo playersInfo = new PlayersInfo();
        playersInfo.PlayersInfos = new List<PlayerInfoClass>();
        
        if (File.Exists(filePath))
        { 
            playersInfo = JsonConvert.DeserializeObject<PlayersInfo>(File.ReadAllText(filePath)); 
        }
        
        //PlayersInfo playersInfo = new PlayersInfo();
        PlayerInfoClass player = new PlayerInfoClass();
        player.Name = userInput.text;
        player.Points = 2000;

        
        playersInfo.PlayersInfos.Add(player);
        var jsonString = JsonConvert.SerializeObject(playersInfo);
        File.WriteAllText(filePath, jsonString);

        //PlayerInfoClass newPlayer = JsonConvert.DeserializeObject<PlayerInfoClass>(File.ReadAllText(filePath));
        //Debug.Log(newPlayer.Name);
        //Debug.Log(newPlayer.Points);

        SceneManager.LoadScene("LadderBoard");
    }

    private void EndGame()
    {
        _player.gameObject.GetComponent<PlayerController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        username.gameObject.SetActive(true);
        userInput.gameObject.SetActive(true);
        btnConfirm.gameObject.SetActive(true);
    }
}
