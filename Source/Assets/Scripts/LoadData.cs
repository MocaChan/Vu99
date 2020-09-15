using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class LoadData
{

    public static Map Loadmap()
    {
        string data = "map1";
        int round = GameCache.round;
        int r = Random.Range(0, 3);

        if (round > 4)
        {
            if (r == 0)
                round = 2;
            else if (r == 1)
                round = 3;
            else
                round = 4;
        }

        switch (round)
        {
            case 1:
                {
                    data = "map1";
                    break;
                }
            case 2:
                {
                    data = "map2";
                    break;
                }
            case 3:
                {
                    data = "map3";
                    break;
                }
            case 4:
                {
                    data = "map4";
                    break;
                }
           }

        data = File.ReadAllText(Application.dataPath + "/"+ data + ".txt");
        Map map = new Map();
        map = JsonUtility.FromJson<Map>(data);

        return map;
    }

}
