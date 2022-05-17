using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float force = 100f;

    private Vector2 resetBallPosition;
    
    private Vector2 startPosition;
    private Vector2 endPosition;

    private Vector3 mousePos;

    private float ballScorePosition;

    private Rigidbody2D physics;

    private LineRenderer lineTrajectory;
    
    void Awake() 
    {
        physics = GetComponent<Rigidbody2D>();
        lineTrajectory = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        physics.isKinematic = true;
        resetBallPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {     
        lineTrajectory.textureMode = LineTextureMode.RepeatPerSegment;
        lineTrajectory.material.SetTextureScale("_MainTex", new Vector2(0.1f , 1));

        mousePos = Input.mousePosition;
        mousePos.z = 10;

        if(Input.GetMouseButtonDown(0))
        {
            startPosition = GetMousePosition();
            
        }

        if(Input.GetMouseButton(0))
        {
            // Code that draws the trajectory line
            endPosition = GetMousePosition();
            Vector2 velocity = (startPosition - endPosition) * force;

            Vector2[] trajectory = Plot(physics, (Vector2)transform.position, velocity, 700);
            
            lineTrajectory.positionCount = trajectory.Length;

            Vector3[] positions = new Vector3[trajectory.Length];
            for (int i = 0; i <trajectory.Length; i++)
            {
                positions[i] = trajectory[i];
            }
            lineTrajectory.SetPositions(positions);
        }

        if(Input.GetMouseButtonUp(0))
        {
            lineTrajectory.positionCount = 0;
            endPosition = GetMousePosition();
            Vector2 velocity = (startPosition - endPosition) * force;

            physics.isKinematic = false;

            physics.velocity = velocity;
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(!other.gameObject.tag.Equals("ground")) return;
        
        physics.isKinematic = true;
        transform.position = resetBallPosition;
        physics.velocity = Vector2.zero;
        physics.angularVelocity = 0f;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        ballScorePosition = transform.position.y;
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(transform.position.y < ballScorePosition)
        {
            Debug.Log("win the game"); // put something here to actually win
            // All this below might not have to exist if it just exits the game anyway
            physics.isKinematic = true;
            transform.position = resetBallPosition;
            physics.velocity = Vector2.zero;
            physics.angularVelocity = 0f;
        }
    }

    private Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    public Vector2[] Plot(Rigidbody2D rigidbody, Vector2 pos, Vector2 velocity, int steps)
    {
        // Code that creates the points behind the trajectory line
        Vector2[] results = new Vector2[steps];

        float timestep = Time.fixedDeltaTime / Physics2D.velocityIterations;
        Vector2 gravityAccel = Physics2D.gravity * rigidbody.gravityScale * timestep * timestep;

        float drag = 1f - timestep * rigidbody.drag;
        Vector2 moveStep = velocity * timestep;

        for (int i = 0; i < steps; i++)
        {
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            results[i] = pos;
        }

        return results;
    }
}
