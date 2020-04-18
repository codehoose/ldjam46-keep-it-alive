using System.Collections;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [Tooltip("Time in seconds before the object self destructs")]
    public float _destroyInSecs;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(_destroyInSecs);
        var rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.Sleep();
        }

        Destroy(gameObject);
    }
}
