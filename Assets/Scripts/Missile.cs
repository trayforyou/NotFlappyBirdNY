using UnityEngine;

public class Missile : MonoBehaviour, IPoolInstance
{
    [SerializeField] int _damage = 1;

    public void Hide()
    {
        throw new System.NotImplementedException();
    }
}