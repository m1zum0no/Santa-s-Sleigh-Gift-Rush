using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonScript : MonoBehaviour
{
    public void OnButtonClick()
    {
        GameController.Instance.ChangeScene("MainMenu");
    }
}
