using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandlerForNoGCScenes : MonoBehaviour
{
   public void OnButtonClick()
    {
        GameController.Instance.ShowAdAndPauseGame(); // ֲûחמג לועמהא טח GameController
    }
}
