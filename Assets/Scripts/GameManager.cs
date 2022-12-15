using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool end;

    [SerializeField] private TextMeshProUGUI username;
    [SerializeField] private GameObject _player;
    [SerializeField] private TMP_InputField userInput;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        end = false;
        username.gameObject.SetActive(false);
        userInput.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (end)
        {
            _player.gameObject.GetComponent<PlayerController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            username.gameObject.SetActive(true);
            userInput.gameObject.SetActive(true);
        }
    }
}
