using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovingObject : EnemyBase
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveToNextWayPoint());
    }

    public override void TakeDamage(float amount)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
