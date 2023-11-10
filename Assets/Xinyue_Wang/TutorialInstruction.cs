using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialInstruction : MonoBehaviour
{
    public TextMeshProUGUI instruction;
    // Start is called before the first frame update
    void Start()
    {
        instruction.text = "Press A to go to the left";
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            instruction.text = "Press D to go to the right";
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            instruction.text = "Press Space to jump";
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            instruction.text = "Press J to shoot";
        }
    }
}
