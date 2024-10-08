using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public SceneController sceneController;
    [SerializeField] private InitialGameData gameData;

    public bool isInMainMenu = true;

    void Update()
    {
        if (isInMainMenu)
        {
            if (Input.GetKeyDown(gameData.jump0))
            {
                isInMainMenu = false;
                sceneController.LoadGameScene();
            }
        }
        else if (player.isDead)
        {
            Time.timeScale = 0f;

            if (Input.GetKeyDown(gameData.jump0))
            {
                player.isDead = false;
                sceneController.LoadMainMenu();
                isInMainMenu = true;
            }
        }
    }
}