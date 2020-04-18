using System.Collections;
using UnityEngine;

public class PickupWeaponAnimation : MonoBehaviour
{
    public AnimationCurve _curve;
    
    public void StartAnimating(string text)
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = text;
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        var time = 0f;
        while(time < 1f)
        {
            var value = _curve.Evaluate(time);
            time += Time.deltaTime / 2f;
            transform.localScale = new Vector3(value, 1, 1);
            yield return null;
        }
        Destroy(gameObject);
    }
}
