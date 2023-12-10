using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToAvaibleLvlScript : MonoBehaviour
{
    public void OnButtonClick()
    {
        GameController.Instance.SwitchToAvaibleLvl();
    }
}
