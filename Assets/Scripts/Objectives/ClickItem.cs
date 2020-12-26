using UnityEngine;

public class ClickItem : AObjective
{
    [SerializeField] Sprite defaultSprite = null;
    [SerializeField] Sprite onPressedSprite = null;

    public override void ResetObjective()
    {
        Completed = false;
        if (defaultSprite != null) GetComponent<SpriteRenderer>().sprite = defaultSprite;
    }

    public override void UpdateState()
    {
        
    }

    void OnMouseDown()
    {
        Completed = true;
        if (onPressedSprite != null) GetComponent<SpriteRenderer>().sprite = onPressedSprite;
    }
}