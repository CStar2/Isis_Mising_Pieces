using UnityEngine;
using UnityEngine.UI;

public class Livebar : MonoBehaviour
{
    private Slider Slider;

    private void Start()
    {
        Slider = GetComponent<Slider>();
    }

    public void maxlive(float max)
    {
        Slider.maxValue = max;
    }
    public void nowlife(float lifelife)
    {
        Slider.value = lifelife;
    }

    public void chancelive(float live)
    {
        maxlive(live);
        nowlife(live);

    }
}
