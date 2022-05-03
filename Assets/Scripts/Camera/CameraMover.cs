using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private CameraNode node;
    
    public float step = 5f;
    float counter = 0;

    public Button leftButton, rightButton;

    private void Start()
    {
        leftButton.onClick.AddListener(LeftButtonClicked);
        rightButton.onClick.AddListener(RightButtonClicked);
    }

    void LeftButtonClicked()
    {
        if (node.GetLeft() != null & node.GetLeft() != node.GetLeft().IsLocked())
        {
            node = node.GetLeft();
            Debug.Log("leftButton");
        }
    }

    void RightButtonClicked()
    {
        if (node.GetRight() != null & node.GetRight() != node.GetRight().IsLocked())
        {
            node = node.GetRight();
            Debug.Log("leftButton");
        }
    }

    void FixedUpdate()
    {     
        if (!Vector3.Equals(transform.position, node.transform.position))
        {
            counter += Time.fixedDeltaTime / step;
            transform.position = Vector3.MoveTowards(transform.position, node.transform.position, counter);
            if (transform.position == node.transform.position) counter = 0;
        }
    }
}