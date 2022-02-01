using UnityEngine;

[RequireComponent(typeof(InputPlayer))]
public class ShootingScript : MonoBehaviour
{
    [SerializeField] private Weapon[] _weapon;
    [SerializeField] private InputPlayer _inputPlayer;

    [SerializeField] private int _currentWeapon;


    private void OnEnable()
    {
        _inputPlayer.ButtonPressed.AddListener(_weapon[_currentWeapon].Shoot);
    }

    private void OnDisable()
    {
        _inputPlayer.ButtonPressed.RemoveListener(_weapon[_currentWeapon].Shoot);
    }
}
