using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    public Text score;
    
    public Text points;

    // Update is called once per frame
    void Update()
    {
        score.text = "You Win\n";
        points.text = PlayerStats.Points.ToString() + " points!";
    }
}