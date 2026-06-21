using UnityEngine;
using System.Collections;

public class LanternLight : MonoBehaviour
{
    public Light lanternLight;
    public float target = 3f;

    public void LightUp()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        float t = 0;
        float start = lanternLight.intensity;

        while (t < 1)
        {
            t += Time.deltaTime;
            lanternLight.intensity = Mathf.Lerp(start, target, t);
            yield return null;
        }
    }
}