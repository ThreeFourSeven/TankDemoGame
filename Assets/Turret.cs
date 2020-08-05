using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Vector3 target;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        target = Vector3.up;
        direction = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = (Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg) - 90.0f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        direction = Vector3.Normalize(target);
    }

    public Vector3 GetDirection() { return direction; }
}
