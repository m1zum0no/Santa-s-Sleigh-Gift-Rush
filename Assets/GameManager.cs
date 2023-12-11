using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text timer;
    [SerializeField] TMP_Text triesLeft;
    int triesInInt;
    float counter;
    [SerializeField] float startCounter;
    void Start()
    {
        triesInInt = GameController.Instance.triesLeft;
        triesLeft.SetText(triesInInt.ToString());
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
