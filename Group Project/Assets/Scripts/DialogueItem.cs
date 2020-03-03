using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueItem : MonoBehaviour
{
    private bool showText = false;
    public string itemText = "Click To Close";
    // Create a bool to say whether to show the button or not

    void OnMouseDown()
    {
        if (!showText)
            showText = true;
        // If you clicked the object, set showText to true
    }

    void OnGUI()
    {
        if (showText)
        {
            // If you've clicked the object, show this button
            if (GUI.Button(new Rect(gameObject.transform.position.x, gameObject.transform.position.z, 100, 20 ), itemText))
                // If you click this button, set showText to false
                showText = false;
        }
    }
    
}
