using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : ProjectileBehaviour
{

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, currentSpeed * Time.deltaTime);
    }

}
