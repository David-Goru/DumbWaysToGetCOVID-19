using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    [SerializeField] Vector3 startPos;
    void OnEnable()
    {
        transform.position = startPos;
    }

    void Update()
    {
        
    }
}