using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int health;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            if (health > 100)
            {
                health = 100;
            }

            if (health < 0)
            {
                health = 0;
            }
        }
    }

    private int score = 0;

    public int Score
    {
        get
        {
            print("Someone get the score");
            return score;
        }
        set
        {
            score = value;

            if (score > 10)
            {
                score = 10;
            }
            print("Score was set to: " + value);
        }
    }

    public static GameManager instance;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
             DontDestroyOnLoad(gameObject);
             instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Score += 7;

        print("Your current score is:" + Score);
    }
}
