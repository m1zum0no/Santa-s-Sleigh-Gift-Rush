using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : MonoBehaviour
{
    public void OnButtonClick()
    {
        GameController.Instance.ChangeScene("Level1");
    }
}

