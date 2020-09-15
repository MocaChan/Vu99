using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Sprite fireWallType1, fireWallType2, fireWallType3, fireWallType4;
    public Text txtTime, txtRound, txtScore, txtScoreEnd;
    public GameObject gameover, panelRound, fireWall, panelEnd, effecHP1, effecHP2, effecHP3;

    int time = 0, round = 0, countFireWall,timeLvl=60;
    float panelRoundTime = 1000, disInputTime = 0, timeStartGame = 30;

    Vector2 gameoverPos;
    Map map;

    void Start()
    {

        Cursor.visible = false;
        GameCache.IsRelife = true;
        GameCache.HP = 3;
        GameCache.IsPlaying = false;
        GameCache.Force = 350;
        GameCache.Score = 0;
        GameCache.countDes = 0;
        GameCache.round = 1;
        gameoverPos = gameover.transform.position;
    }

    void Update()
    {
        CheckStartGame();
        CheckTime();
        CheckRound();
        CheckHP();
        DisableInput2S();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            Cursor.visible = true;
        }
    }

    void CheckTime()
    {
        txtScore.text = "SCORE: " + string.Format("{0:#,0}", GameCache.Score);

        if (GameCache.IsPlaying == true && (Time.time > time+timeStartGame||GameCache.HP==0))
        {
            if (time == timeLvl || GameCache.HP == 0)
            {
                GameCache.IsPlaying = false;
                disInputTime += 10000;

                gameover.SetActive(true);

                Cursor.visible = true;
                txtScoreEnd.text = "SCORE: " + string.Format("{0:#,0}", GameCache.Score);
                panelEnd.SetActive(true);
                return;
            }
            time++;
            txtTime.text = (timeLvl - time).ToString();
            GameCache.Time = time;
        }
    }
    void CheckStartGame()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && GameCache.IsPlaying == false)
        {
            timeStartGame = Time.time;
            GameCache.IsPlaying = true;
        }
    }
    void CheckHP()
    {
        if (GameCache.HP == 2)
            effecHP3.SetActive(false);
        if (GameCache.HP == 1)
            effecHP2.SetActive(false);
        if (GameCache.HP == 0)
        {
            effecHP2.SetActive(false);
        }
    }
    void CheckRound()
    {
        Debug.Log(GameCache.countDes + " _ " + countFireWall+" - "+Time.time);
        if (GameCache.countDes == countFireWall)
        {
            panelRoundTime = Time.time;
            disInputTime = Time.time + 1.5f;
            ++round;
            time = 0;

            GameCache.round = round;
            GameCache.countDes = 0;
            GameCache.IsPlaying = false;
            GameCache.IsRelife = true;
            panelRound.SetActive(true);

            createMap();
            LevelUp();

            txtTime.text = (timeLvl).ToString();
            txtRound.text = "ROUND " + round.ToString();
        }
        if (Time.time > panelRoundTime + 1.5f)
            panelRound.SetActive(false);
    }

    void DisableInput2S()
    {
        if (Time.time < disInputTime)
            GameCache.IsPlaying = false;
        //else
        //    GameCache.IsPlaying = true;
    }

    public void createMap()
    {
        map = new Map();
        map = LoadData.Loadmap();

        countFireWall = map.total;

        for (int i = 0; i < map.total; i++)
        {
            Vector3 vec = new Vector3(map.FireWall[i].x, map.FireWall[i].y, map.FireWall[i].z);

            var objFireWall = Instantiate(fireWall, vec, Quaternion.identity);
            objFireWall.transform.eulerAngles = new Vector3(0,0,map.FireWall[i].rotate);

            switch (map.FireWall[i].type)
            {
                case 1:
                    {
                        objFireWall.GetComponent<SpriteRenderer>().sprite = fireWallType1;
                        objFireWall.gameObject.tag = "Type1";
                        break;
                    }
                case 2:
                    {
                        objFireWall.GetComponent<SpriteRenderer>().sprite = fireWallType2;
                        objFireWall.gameObject.tag = "Type2";
                        break;
                    }
                case 3:
                    {
                        objFireWall.GetComponent<SpriteRenderer>().sprite = fireWallType3;
                        objFireWall.gameObject.tag = "Type3";
                        break;
                    }
                case 4:
                    {
                        objFireWall.GetComponent<SpriteRenderer>().sprite = fireWallType4;
                        objFireWall.gameObject.tag = "Type4";
                        break;
                    }
            }
        }
    }

    void LevelUp()
    {
        if (timeLvl > 30 && round!=1)
        {
            timeLvl -= 5;
            GameCache.Force += 60;
            return;
        }
        GameCache.Force += 10;
    }
}