using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIComponents : MonoBehaviour
{
    public Image hand;
    public Image redPoint;
    public Canvas canvas;
    public GameObject pointParent;
    [SerializeField] private GameObject gamePausedPanel,levelFailedPanel,levelCompletedPanel,failedBallCountPanel;
    public static UIComponents instance;
    private void Awake()
    {
        instance = this;
    }
    //Change failed ball count text
    public void ChangeTextToFailedBallCount(string text)
    {
        failedBallCountPanel.GetComponentInChildren<Text>().text = text;
    }
    //Pause game and open gamePausedPanel
    public void PauseGame()
    {
        gamePausedPanel.SetActive(true);
        Time.timeScale = 0;        
    }
    //if game pause close gamePausedPanel and continue game
    public void ContinueGame()
    {
        gamePausedPanel.SetActive(false);
        Time.timeScale = 1;
    }
    //load current scene again
    public void PlagAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //open to  levelFailedPanel
    public void LevelFailed()
    {
        levelFailedPanel.SetActive(true);
        Time.timeScale = 0;
    }
    //open to levelCompletedPpanel
    public void LevelCompleted()
    {
        levelCompletedPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
