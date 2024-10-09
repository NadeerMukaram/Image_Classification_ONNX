using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Move : MonoBehaviour
{
    public TextMeshProUGUI textStatus; // The TextMeshProUGUI component to get the string from
    public float moveAmount = 1.0f; // The amount by which the object should move

    // Update is called once per frame
    void Update()
    {
        // Check if textStatus is assigned
        if (textStatus != null)
        {
            // Get the string from the TextMeshProUGUI component
            string status = textStatus.text;

            // Check if the string is "Up" and move the object up
            if (status == "Up")
            {
                transform.position += new Vector3(0, moveAmount * Time.deltaTime, 0); // Move up
            }
            // Check if the string is "Down" and move the object down
            else if (status == "Down")
            {
                transform.position += new Vector3(0, -moveAmount * Time.deltaTime, 0); // Move down
            }
        }
    }
}
