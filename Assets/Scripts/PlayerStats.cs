using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private static int points, health, numberOfHearts;

    public static int Points
    {
        get
        {
            return points;
        }
        set
        {
            points = value;
        }
    }

    public static int HealthStats
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
}
