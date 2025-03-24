using UnityEngine;
using UnityEngine.InputSystem;

public class QuitApplication : MonoBehaviour
{
    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Debug.Log("We pushed escape, aren't we clever");
            Application.Quit();
        }
    }
}
