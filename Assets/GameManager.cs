using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text timer;
    float counter;
    [SerializeField] float startCounter;
    void Start()
    {
        counter = startCounter;
    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;
        timer.text = counter.ToString("F0");
        if (counter <= 0)
        {
            GameController.Instance.LevelEnding();
        }
    }
}
