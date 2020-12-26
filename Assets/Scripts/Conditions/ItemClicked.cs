using UnityEngine;

public class ItemClicked : ACondition
{
    [SerializeField] Sprite defaultSprite = null;
    [SerializeField] Sprite onPressedSprite = null;

    public override void ResetCondition()
    {
        Reached = false;
        if (defaultSprite != null) GetComponent<SpriteRenderer>().sprite = defaultSprite;
    }

    public override void UpdateState(float time)
    {
        
    }

    void OnMouseDown()
    {
        Reached = true;
        if (onPressedSprite != null) GetComponent<SpriteRenderer>().sprite = onPressedSprite;
    }
}