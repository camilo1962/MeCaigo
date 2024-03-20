using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject panelGameOver;


    // Start is called before the first frame update
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void RestartGame()
    {
        SoundManager.instance.Gameoversound();
        Invoke("RestartAfterTime", 1f);
        SoundManager.instance.Gameoversound();
    }
    void RestartAfterTime()
    {
        panelGameOver.SetActive(true);
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Gamescene");
        SoundManager.instance.GameOverSonido();
    }
    void Start()
    {
        panelGameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Otra()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gamescene");
    }
}






