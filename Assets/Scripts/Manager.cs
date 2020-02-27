using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public int levelCount = 50;
    public Text coin;
    public Text distance;
    public Camera camera;
    public GameObject guiGameOver;
    public LevelGenerator LevelGenerator;

    private int currentCoins = 0;
    private int currentDistance = 0;
    private bool canPlay = false;

    private static Manager s_Instance;
    public static Manager insance
    {
        get
        {
            if(s_Instance == null)
            {
                s_Instance = FindObjectOfType(typeof(Manager)) as Manager;
            }
            return s_Instance;
        }
    }

    private void Start()
    {
        for(int i = 0; i < levelCount; i++)
        {
            LevelGenerator.RandomGenerator();
        }
    }

    public void UpdateCoinCount(int value)
    {
        Debug.Log("Player picked up another coin for" + value);
        currentCoins += value;
        coin.text = currentCoins.ToString();
    }
    public void UpdateDistanceCount()
    {
        Debug.Log("Player moved forward for one point");
        currentDistance += 1;
        distance.text = currentDistance.ToString();
        LevelGenerator.RandomGenerator();
    }
    public bool CanPlay()
    {
        return canPlay;
    }
    public void StartPlay()
    {
        canPlay = true;
    }
    public void GameOver()
    {
        camera.GetComponent<CameraShake>().Shake();
        camera.GetComponent<CameraShake>().enabled = false;

        GuiGameOver();
    }
    void GuiGameOver()
    {
        Debug.Log("GameOver!");
        guiGameOver.SetActive(true);
    }
    public void PlayAgain()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
