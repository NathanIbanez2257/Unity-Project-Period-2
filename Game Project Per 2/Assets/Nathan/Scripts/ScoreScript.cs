using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public  int _scoreValue = 0;
    [SerializeField] private Text _score;
    //[SerializeField] private TextMeshPro _scoreText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _score.text = "Zombie Kills: " + _scoreValue;
    }
}
