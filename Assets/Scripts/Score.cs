using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject player;

    public Text score;
    // Update is called once per frame
    void Update()
    {
        score.text = PlayerStats.Points.ToString();
    }
}
