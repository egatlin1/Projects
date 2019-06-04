using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_GameMenu : MonoBehaviour
{

    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start ( )
    {

    }

    // Update is called once per frame
    void Update ( )
    {
        if ( Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
    }

    private void PauseMenu ( )
    {
        if ( Rain_Lives.instance.IsGameOver() )
            return;

        if ( pauseMenu.activeSelf )
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }


    public void MenuButtonResponse ( )
    {
        FindObjectOfType<SceneController>().LoadScene("Rain_Menu");
    }
    


}
