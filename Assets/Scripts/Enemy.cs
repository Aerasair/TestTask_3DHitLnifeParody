using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;


    [SerializeField] private WaypointsKillCounter _waypointsKillCounter;

    private int _currentHealth;
    private bool _isAlive = true;

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0 && _isAlive == true)
        {
            _waypointsKillCounter.KillMob();
            _isAlive = false;

            GetComponent<Animator>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

}
