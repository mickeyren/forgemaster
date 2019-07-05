using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public LineFactory lineFactory;

    private Vector2 start;
    private Line drawnLine;

    void Start()
    {
        lineFactory.GetLine(new Vector2(-1.0f, 5.0f), new Vector2(-2.0f, -5.0f), 0.02f, Color.red);
        lineFactory.GetLine(new Vector2(0.0f, 5.0f), new Vector2(0.0f, -5.0f), 0.02f, Color.green);
        lineFactory.GetLine(new Vector2(1.0f, 5.0f), new Vector2(2.0f, -5.0f), 0.02f, Color.blue);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing
            drawnLine = lineFactory.GetLine(pos, pos, 0.02f, Color.black);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            drawnLine = null; // End line drawing
        }

        if (drawnLine != null)
        {
            drawnLine.end = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Update line end
        }
    }

    /// <summary>
    /// Get a list of active lines and deactivates them.
    /// </summary>
    public void Clear()
    {
        var activeLines = lineFactory.GetActive();

        foreach (var line in activeLines)
        {
            line.gameObject.SetActive(false);
        }
    }
}
