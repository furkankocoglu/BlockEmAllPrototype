using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int failedBallCount = 0;
    public int ballCount=0;
    public int neededBalls = 5;
    public static LevelManager instance;
    private void Awake()
    {
        instance = this;
    }
    public void CountBall()
    {
        failedBallCount++;
        UIComponents.instance.ChangeTextToFailedBallCount(failedBallCount+"/3");
        IncreaseBall();
        if (failedBallCount>=3 && ballCount<neededBalls)
        {
            UIComponents.instance.LevelFailed();            
        }
    }
    public void IncreaseBall()
    {
        ballCount++;
        if (ballCount>=neededBalls)
        {
            UIComponents.instance.LevelCompleted();
        }
    }
}
