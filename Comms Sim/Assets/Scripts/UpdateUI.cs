using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI textUI;
    public DrawLine lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        textUI = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        double dist = lineRenderer.getDistance() * 10000.0;
        double time  = dist / (2.98*10e5);
        textUI.text = System.String.Format("Distance: {0:00000.000} km\nEst. Arrival {1:00000.000} seconds", dist, time);
        // textUI.text = "Distance: " + dist + "\nEst. Arrival: " + time;
        //Debug.Log("Distance: " + dist + "\nEst. Arrival: " + time);

    }
}
