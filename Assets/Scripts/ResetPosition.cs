using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    [SerializeField] Vector3 startPos;
    void Start()
    {
        transform.position = startPos;
    }

    void Update()
    {
        
    }
}