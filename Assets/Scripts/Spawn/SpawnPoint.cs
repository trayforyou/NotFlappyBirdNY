using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public void SetEnemyPosition(Enemy enemy)
    {
        enemy.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
    }
}