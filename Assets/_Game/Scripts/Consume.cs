using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consume : MonoBehaviour
{
    public OnTriggerEvents onTriggerEvents;

    public void Activate()
    {
        Debug.Log($"Cursor: {onTriggerEvents.gameObject.GetComponent<ColorTag>().color}");
        Debug.Log($"Creature: {onTriggerEvents.triggerData.gameObject.GetComponent<ColorTag>().color}");
        if (onTriggerEvents.gameObject.GetComponent<ColorTag>().color != onTriggerEvents.triggerData.gameObject.GetComponent<ColorTag>().color) return;
        onTriggerEvents.triggerData.gameObject.GetComponent<Creature>().Die();
    }
}
