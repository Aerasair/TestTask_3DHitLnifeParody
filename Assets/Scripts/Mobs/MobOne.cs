using UnityEngine;

public class MobOne : Enemy
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bullet")
        {
            TakeDamage(1000);
        }
    }
}
