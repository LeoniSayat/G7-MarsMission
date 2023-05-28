using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// [RequireComponent(typeof(DrawLine), typeof(PolygonCollider2D))]
[RequireComponent(typeof(DrawLine))]
public class LineCollision : MonoBehaviour{

    DrawLine lineController;
    public GameObject test;
    // public GameObject Earth;
    // public GameObject Mars;
    // public Vector3 collision = Vector3.zero;
    // public LayerMask layer; 
    BoxCollider collider; 
    Transform temp;
    LineRenderer lr; 

    public static bool canSend = true;

    PolygonCollider2D polygonCollider;

    void Awake() {
        lineController = GetComponent<DrawLine>();
        //collider = GetComponent<BoxCollider>();
        temp = GetComponent<Transform>();
        lr = GetComponent<LineRenderer>();
        

        polygonCollider = GetComponent<PolygonCollider2D>();
    }

    void OnCollision2DEnter(Collision2D collision){
        if (collision.gameObject.name == "SunCollider"){
            // Debug.Log(collision.gameObject.name);
            canSend = false;
            lr.startColor = Color.red; 
            lr.endColor = Color.red;
        }
        
    }

    void OnCollision2DExit(Collision2D collision){
        if (collision.gameObject.name == "SunCollider"){
            // Debug.Log(collision.gameObject.name);
            canSend = true;
            lr.startColor = Color.green; 
            lr.endColor = Color.green;
        }
        
    }

    public static bool askSend(){
        return canSend;
    }
    // void Update(){
    //     // Vector3 dir = (Mars.transform.position - Earth.transform.position);
    //     // var ray = new Ray(Earth.transform.position, dir);
    //     // RaycastHit hit; 
    //     // if (Physics.Raycast(Earth.transform.position, dir, layer)){
    //     //     //collision = hit.point;
    //     //     Debug.Log("Hit the sun!");
    //     // }

    //      // Calculate the direction vector from startPoint to endPoint
    //     Vector3 direction = Vector3.Normalize(Mars.transform.position - Earth.transform.position);
    //     // Debug.Log(Earth.transform.position);

    //     // Cast a ray from startPoint in the direction of direction
    //     Ray ray = new Ray(Earth.transform.position, direction);
    //     RaycastHit hit;

    //     // Perform the raycast and check for hits on the "SunRay" layer
    //     if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.layer == layer)
    //     {
    //         Debug.Log("Hit on SunRay layer detected!");
    //     }
    // }

    // void OnDrawGizmos(){
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(collision, 0.2f);
    // }

    void LateUpdate() { 

        // Vector3 Earth = lineController.startpos;
        // Vector3 Mars = lineController.destpos;
        // float distance = lineController.getDistance();
        // Vector3 midpoint =Vector3.Lerp(Mars, Earth, 0.5f); 
        // // collider.center = midpoint;
        // temp.position = midpoint;


        // // float rot = (distance * (Mathf.PI - Mathf.Asin(Mathf.Clamp((Mars.z - Earth.z) / distance, -1f, 1f))));
        // float rot = (distance *(Mathf.Asin(Mathf.Clamp((Mars.z - Earth.z) / distance, -1f, 1f))));
        // // Vector3 relative = Mars - Earth;
        // // float rot = Mathf.Atan2(relative.x, relative.z) / Mathf.PI * 180;
        // temp.rotation = new Quaternion(distance, 0f, 180 + rot, 0f);
        // temp.rotation = Quaternion.Euler(0f, temp.rotation.eulerAngles.y, 0f);
        // collider.size = new Vector3(distance, 50f, 50f);

        // Get all the positions from the line renderer
        Vector2[] positions = {lineController.startpos,lineController.destpos};
        List<Vector2> currentPositions = new List<Vector2> {lineController.startpos,lineController.destpos};
        List<Vector2> currentColliderPoints = CalculateColliderPoints(currentPositions);
        // // this line doesnt work try raycasting?
        // collider.size();
        
        //If we have enough points to draw a line
        if (positions.Count() >= 2) {

            //Get the number of line between two points
            int numberOfLines = positions.Length - 1;

            //Make as many paths for each different line as we have lines
            polygonCollider.pathCount = numberOfLines;

            //Get Collider points between two consecutive points
            for (int i = 0; i < numberOfLines; i++) {
                //Get the two next points
                currentPositions = new List<Vector2> {
                    positions[i],
                    positions[i+1]
                };

                currentColliderPoints = CalculateColliderPoints(currentPositions);
                polygonCollider.SetPath(i, currentColliderPoints.ConvertAll(p => (Vector2)transform.InverseTransformPoint(p)));
            }
        }
        else {

            polygonCollider.pathCount = 0;
        }
    }

    // List<Vector3> CalculateColliderPoints(List<Vector3> positions)
    // {
    //     // Get the Width of the Line
    //     float width = 10f;

    //     // m = (z2 - z1) / (x2 - x1)
    //     float m = (positions[1].z - positions[0].z) / (positions[1].x - positions[0].x);
    //     float deltaX = (width / 2f) * (m / Mathf.Pow(m * m + 1, 0.5f));
    //     float deltaZ = (width / 2f) * (1 / Mathf.Pow(1 + m * m, 0.5f));

    //     // Calculate Vertex Offset from Line Point
    //     Vector3[] offsets = new Vector3[2];
    //     offsets[0] = new Vector3(-deltaX, 50f, deltaZ);
    //     offsets[1] = new Vector3(deltaX, 50f, -deltaZ);

    //     List<Vector3> colliderPoints = new List<Vector3>
    //     {
    //         positions[0] + offsets[0],
    //         positions[2] + offsets[0],
    //         positions[2] + offsets[2],
    //         positions[0] + offsets[2]
    //     };

    //     return colliderPoints;
    // }

    private List<Vector2> CalculateColliderPoints(List<Vector2> positions) {
        //Get The Width of the Line
        float width = 10f;

        // m = (y2 - y1) / (x2 - x1)
        float m = (positions[1].y - positions[0].y) / (positions[1].x - positions[0].x);
        float deltaX = (width / 2f) * (m / Mathf.Pow(m * m + 1, 0.5f));
        float deltaY = (width / 2f) * (1 / Mathf.Pow(1 + m * m, 0.5f));

        //Calculate Vertex Offset from Line Point
        Vector2[] offsets = new Vector2[2];
        offsets[0] = new Vector2(-deltaX, deltaY);
        offsets[1] = new Vector2(deltaX, -deltaY);

        List<Vector2> colliderPoints = new List<Vector2> {
            positions[0] + offsets[0],
            positions[1] + offsets[0],
            positions[1] + offsets[1],
            positions[0] + offsets[1]
        };

        return colliderPoints;
    }
    
}
