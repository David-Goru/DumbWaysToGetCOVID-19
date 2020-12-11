using UnityEngine;

/// <summary>
/// This is a class
/// </summary>
public class ChangeOrderInLayerOnSomeXPos : MonoBehaviour
{
    [SerializeField] SpriteRenderer sp;
    [SerializeField] int initialLayer;
    [SerializeField] int finalLayer;
    [SerializeField] float xPos;

    private void OnEnable()
    {
        sp.sortingOrder = initialLayer;
    }

    void Update()
    {
        if(transform.position.x >= xPos)
        {
            sp.sortingOrder = finalLayer;
        }
    }
}