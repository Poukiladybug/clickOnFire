using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    public Manager manager;
    public TextMeshProUGUI scoreText;
    public int score;
    // Start is called before the first frame update
    private void Start()
    {
        if (manager == null)
        {
            manager = FindObjectOfType<Manager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        score = PlayerPrefs.GetInt("score", 0);
        scoreText.text = "score: " + score;
    }
}
