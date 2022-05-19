using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public UnityEvent onComplete;

    [SerializeField] float force = 100f;
    [SerializeField] int steps = 700;

    private Vector2 resetBallPosition;

    private float ballScorePosition;

    private Rigidbody2D physics;

    private LineRenderer lineTrajectory;

    private Vector2 userForceInput;

    public Button fireButton;
    public InputField xValue, yValue;
    
    void Awake() 
    {
        physics = GetComponent<Rigidbody2D>();
        lineTrajectory = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (onComplete == null) onComplete = new UnityEvent();

        physics.isKinematic = true;
        resetBallPosition = transform.position;
        fireButton.onClick.AddListener(FireButtonClicked);
    }

    void FireButtonClicked()
    {
        if(physics.isKinematic == true)
        {
            Vector2 velocity = (userForceInput) * force;

            physics.isKinematic = false;
            physics.velocity = velocity;
        }
    }

    public void ValueChangeCheck()
    {
        if(physics.isKinematic == true)
        {
            CreateTrajectoryLine();
        }
    }

    void CreateTrajectoryLine()
    {
        float.TryParse(xValue.text, out float x);
            float.TryParse(yValue.text, out float y);

            userForceInput.x = x/10;
            userForceInput.y = y/10;

            // Code that draws the trajectory line
            Vector2 velocity = (userForceInput) * force;

            Vector2[] trajectory = Plot(physics, (Vector2)transform.position, velocity, steps);
                
            lineTrajectory.positionCount = trajectory.Length;

            Vector3[] positions = new Vector3[trajectory.Length];
            for (int i = 0; i <trajectory.Length; i++)
            {
                positions[i] = trajectory[i];
            }
            lineTrajectory.SetPositions(positions);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(!other.gameObject.tag.Equals("ground")) return;
        
        physics.isKinematic = true;
        transform.position = resetBallPosition;
        physics.velocity = Vector2.zero;
        physics.angularVelocity = 0f;
        CreateTrajectoryLine();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        ballScorePosition = transform.position.y;
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(transform.position.y < ballScorePosition)
        {
            onComplete.Invoke();
            physics.isKinematic = true;
            transform.position = resetBallPosition;
            physics.velocity = Vector2.zero;
            physics.angularVelocity = 0f;
            lineTrajectory.positionCount = 0;
            fireButton.enabled = false;
            xValue.enabled = false;
            yValue.enabled = false;
        }
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
