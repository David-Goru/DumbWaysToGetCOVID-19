using UnityEngine;
using UnityEngine.UI;

public class Live : MonoBehaviour
{
    Animator anim;
    Image image;
    [SerializeField] Sprite starterImage;
    [SerializeField] Sprite infectedImage;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        image = GetComponent<Image>();
    }

    public void loseLive()
    {
        if(anim == null)
        {
            anim = GetComponent<Animator>();
        }
        anim.SetTrigger("LoseLive");
    }

    public void setImage(bool isLost)
    {
        if(image == null)
        {
            image = GetComponent<Image>();
        }
        if (isLost)
            image.sprite = infectedImage;
        else
            image.sprite = starterImage;
    }
}