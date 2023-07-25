using UnityEngine.Events;
using UnityEngine;
/// <summary>
/// A simple script to invoke different unity events based on mouse click
/// </summary>
public class ClickEvents : MonoBehaviour
{
    public UnityEvent leftClickEvent;
    public UnityEvent rightClickEvent;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Click Invoked");
            leftClickEvent.Invoke();
        }

        if(Input.GetMouseButtonDown(1)) 
        {
            rightClickEvent.Invoke();
        }
    }
}
