using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpdateUI : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI textUI;
    public DrawLine lineRenderer;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        textUI = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        double dist = lineRenderer.getDistance() * 10000.0;
        String time  = (LineCollision.askSend()) ? System.String.Format("{0:00000.000}", (dist / (299792.458))) : "N/A";
        textUI.text = System.String.Format("Distance: {0:00000.000} km\nEst. Arrival {1} seconds", dist, time);
        // textUI.text = System.String.Format("Distance: {0:00000.000} km\nEst. Arrival {1} seconds\nCurrent runtime: {2}", dist, time, ++count);
        // textUI.text = "Distance: " + dist + "\nEst. Arrival: " + time;
        //Debug.Log("Distance: " + dist + "\nEst. Arrival: " + time);

    }
}
