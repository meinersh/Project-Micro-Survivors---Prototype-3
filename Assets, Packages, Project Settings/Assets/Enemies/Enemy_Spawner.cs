using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;

    [SerializeField] private float Min_Spawn_Time;

    [SerializeField] private float Max_Spawn_Time;

    [SerializeField] private float Spawn_Distance_From_Player = 18;

    private float Time_Until_Spawn;

    private GameObject Player;

    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == true)
        {
            this.transform.position = Player.transform.position;
        }
            

        Time_Until_Spawn -= Time.deltaTime;

        if(Time_Until_Spawn <= 0 && Game_Control.Total_Enemies <= Game_Control.Max_Enemies)
        {
            int choice = PickEnemy();
            switch (choice)
            {
                case 0:
                {
                    SpawnEnemy(choice, 4);
                    break;
                }
                case 1:
                {
                    SpawnEnemy(choice, 12);
                    break;
                }
            }
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        switch (Game_Control.Game_Total_Time)
        {
            case (<= 20):
                Time_Until_Spawn = Random.Range(Min_Spawn_Time, Max_Spawn_Time);
                break;
            case (> 20 and <= 40):
                Time_Until_Spawn = Random.Range(Min_Spawn_Time, Max_Spawn_Time - 1);
                break;
            case (> 40 and <= 80):
                Time_Until_Spawn = Random.Range(Min_Spawn_Time - 0.5f, Max_Spawn_Time - 2);
                break;
            case (> 80):
                Time_Until_Spawn = Random.Range(Min_Spawn_Time - 0.9f, Max_Spawn_Time - 2.5f);
                break;
        }
    }
    public void SpawnEnemy(int type, int amount)
    {
        float _x, _y;
        Vector3 Final_Spawn_Point;

        for (int i = 0; i < amount; i++)
        {
            (_x, _y) = Get_Spawn_X_Y();

            Final_Spawn_Point = new Vector3(Player.transform.position.x + _x,Player.transform.position.y + _y, 0);

            Instantiate(enemyPrefab[type], Final_Spawn_Point, Quaternion.identity);
        }
    }
    private int PickEnemy()
    {
        int _option; //Temp Variable

        //Generates a random number between 0 and the length of the enemyPrefab array
        _option = Random.Range(0, enemyPrefab.Length);

        //returns the variable
        return _option;
    }

    (float, float) Get_Spawn_X_Y()
    {
        int _temp_int = Random.Range(0, 2); //If 0 Then above or below the player. If 1 then to the right or left of the player

        int _Up_Or_Down = Random.Range(0, 2);
        int _Right_Or_Left = Random.Range(0, 2);

        float _x = 0, _y = 0;

        if (_temp_int == 0)
        {
            if (_Up_Or_Down == 0) //Above
            {
                _y = Spawn_Distance_From_Player;
            }
            else //Below
            {
                _y = -Spawn_Distance_From_Player;
            }

            _x = Random.Range(-Spawn_Distance_From_Player, Spawn_Distance_From_Player);
        }
        else if (_temp_int == 1)
        {
            if (_Right_Or_Left == 0) //Right
            {
                _x = Spawn_Distance_From_Player;
            }
            else //Left
            {
                _x = -Spawn_Distance_From_Player;
            }

            _y = Random.Range(-Spawn_Distance_From_Player, Spawn_Distance_From_Player);
        }
        else
        {
            Debug.Log("Enemy TP Error");
        }

        return (_x, _y);
    }
}
