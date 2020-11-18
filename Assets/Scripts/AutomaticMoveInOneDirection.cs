using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticMoveInOneDirection : MonoBehaviour
{
    [SerializeField] bool right;
    [SerializeField] float speed = 2f;

    private void Update()
    {
        if (right)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
