using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Button restart;
    public Button quit;

    public GameObject[] toDestroy;
    
    // Start is called before the first frame update
    void Start()
    {
        restart.onClick.AddListener(RestartLevel);
        quit.onClick.AddListener(QuitGame);
    }

    private void RestartLevel()
    {
        foreach (GameObject obj in toDestroy)
        {
            Destroy(obj);
        }
        SceneManager.LoadScene("Main");
        
        
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
