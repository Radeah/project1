using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    // Array to store dialogue lines
    public string[] dialogueLines;

    // Flag to track whether dialogue is active
    private bool isDialogueActive = false;

    // Index to keep track of current dialogue line
    private int currentDialogueIndex = 0;

    private void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch phase began and if the touch position intersects with the NPC collider
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Touch detected");

                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Check if the ray intersects with the NPC collider
                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
                {
                    Debug.Log("NPC touched");
                    // Start the dialogue if the NPC was touched
                    StartDialogue();
                }
            }
        }
    }

    // Method to start the dialogue
    public void StartDialogue()
    {
        Debug.Log("Dialogue started");
        isDialogueActive = true;
        currentDialogueIndex = 0;
        DisplayNextLine();
    }

    // Method to display the next line of dialogue
    public void DisplayNextLine()
    {
        if (currentDialogueIndex < dialogueLines.Length)
        {
            Debug.Log(dialogueLines[currentDialogueIndex]);
            currentDialogueIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    // Method to end the dialogue
    public void EndDialogue()
    {
        Debug.Log("End of dialogue");
        isDialogueActive = false;
        currentDialogueIndex = 0;
    }

    // Method to check if dialogue is active
    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }
}

