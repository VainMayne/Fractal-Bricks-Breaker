using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    [SerializeField] Text ballCount;
    [SerializeField] Text degree;
    [SerializeField] Text fractalName;
    [SerializeField] Text levelCount;
    [SerializeField] Text highscore;
    [SerializeField] Text scoreEnd;
    [SerializeField] Text newHighscoreText;
    [SerializeField] GameObject panel;
    [SerializeField] Text coinCountText;
    [SerializeField] GameObject gameOverCloud;

    private bool isBallSpawnMoveAllowed = true;

    public void setBallSpawnMoveAllowed(bool isAllowed)
    {
        isBallSpawnMoveAllowed = isAllowed;
    }

    public bool getIsBallSpawnMoveAllowed()
    {
        return isBallSpawnMoveAllowed;
    }

    public void increaseBall(int a)
    {
        int currentCount = int.Parse(ballCount.text);
        currentCount = currentCount + a;
        ballCount.text = currentCount.ToString();
    }


    public void decreaseBall()
    {
        int currentCount = int.Parse(ballCount.text);
        currentCount--;
        ballCount.text = currentCount.ToString();
    }

    public int returnBallCount()
    {
        return int.Parse(ballCount.text);
    }


    public void setDegree(int a)
    {
        degree.text = "Degree: " + (a+1).ToString();
    }

    public void setDegreeString()
    {
        degree.text = "Special Level!";
    }

    public void setFractalName(string name)
    {
        fractalName.text = name;
    }

    public void collectBalls()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }
        Debug.Log("Collect Clicked!");
    }

    public void goMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");

    }


    public void increaseLevel(int a)
    {
        int temp = int.Parse(levelCount.text);
        temp = temp + a;
        levelCount.text = temp.ToString();
    }

    public int getLevel()
    {
        return int.Parse(levelCount.text);
    }

    public void setLevel(int a)
    {
        levelCount.text = a.ToString();
    }

    public void setHighscore(int a)
    {
        highscore.text = "Highscore: " + a.ToString();
    }

    public void setScoreEnd(string a)
    {
        scoreEnd.text = a;
    }

    public void setNewHighscoreText(string a)
    {
        newHighscoreText.text = a;
    }

    public void panelSetActive()
    {
        panel.SetActive(true);
        gameOverCloud.SetActive(true);
    }

    public void panelSetInactive()
    {
        panel.SetActive(false);
        gameOverCloud.SetActive(false);

    }

    public bool isPanelActive()
    {
        return panel.activeInHierarchy;
    }

    public void panelScaleAnimationToOne()
    {
        LeanTween.scale(panel, new Vector3(1f, 1f, 1f), 2f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.rotateAroundLocal(panel, Vector3.forward, 720f, 1f).setEase(LeanTweenType.easeOutCubic);

    }

    public void panelScaleToZero()
    {
        panel.transform.localScale = new Vector3(0f, 0f, 0f);
    }

    public void coinIncrease(int a)
    {
        int temp = int.Parse(coinCountText.text);
        temp = temp + a;
        coinCountText.text = "Coins: " + temp.ToString();
    }

    public void coinDecrease(int a)
    {
        int temp = int.Parse(coinCountText.text);
        temp = temp - a;
        coinCountText.text = "Coins: " + temp.ToString();
    }


    public void setCoin(int a)
    {
        coinCountText.text = "Coins: " + a.ToString();
    }

    public bool isEnough(int limit)
    {
        if(int.Parse(coinCountText.text) >= limit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddMoneyHack()
    {
        PlayerPrefs.SetInt("CoinAmount", PlayerPrefs.GetInt("CoinAmount") + 50);
        setCoin(PlayerPrefs.GetInt("CoinAmount"));
    }
}
