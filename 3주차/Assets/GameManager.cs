using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I; //static 게임 전체에서 단 하나, 싱글톤
    public int Score;

    private void Awake() //Awake는 Start와 동일하지만 그보다 한 단계 앞에서 시작
    {
        I = this; //싱글톤 구현
    }

    public void GameOver()
    {
        Invoke("GameOver_", 2);
    }

    public void WinGame()
    {
        GameOver_();
    }

    public void AddScore(int score)
    {
        Score = Score + score;
        Debug.Log(Score.ToString());
    }

    void GameOver_()
    {
        SceneManager.LoadScene(0);
    }
}
