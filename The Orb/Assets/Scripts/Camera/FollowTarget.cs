using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private float _distance;

    public Transform _target;

    public Transform _focus;

    void Awake()
    {
        _distance = 10f;
        _focus = _focus == null ? _target : _focus;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var x = _target.position.x;
        var z = _target.position.z - _distance;
        var y = transform.position.y;

        transform.position = Vector3.Lerp(transform.position, new Vector3(x, y, z), Time.deltaTime * 10f);
        transform.LookAt(_focus);
    }
}
