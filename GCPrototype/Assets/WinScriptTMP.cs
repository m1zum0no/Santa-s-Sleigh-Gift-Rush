using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScriptTMP : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        GameController.Instance.SetLevelStatus(true); // ֲûחמג לועמהא טח GameController
    }
}
