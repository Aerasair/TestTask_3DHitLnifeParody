using UnityEngine;
using UnityEngine.Events;

public class InputPlayer : MonoBehaviour
{
    public UnityEvent ButtonPressed;

    private void Start()
    {
        if (ButtonPressed == null)
            ButtonPressed = new UnityEvent();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && ButtonPressed != null)
        {
            ButtonPressed.Invoke();
        }
    }

}

