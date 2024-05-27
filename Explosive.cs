using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Explosive : MonoBehaviour
{
    [SerializeField] public ColorSeter _colorSeter;
    [SerializeField] public float _explosionRadius;
    [SerializeField] public float _explosionForce;
    [SerializeField] private int _spawnChance = 100;

    private int _maxSpawningExplosiveCount = 6;
    private int _minSpawningExplosiveCount = 2;

    private void OnMouseDown()
    {
        Explode();
    }

    private void Explode()
    {
        foreach (Collider collider in GetColliders())
        {
            if (collider.TryGetComponent(out Explosive explosive))
                collider.attachedRigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        if (ChanceGenerator.CheckChance(_spawnChance))
            SpawnExplosive();

        Destroy(gameObject);
    }

    private void SpawnExplosive()
    {
        int spawningExplosiveCount = NumberGenerator.GenerateNumber(_minSpawningExplosiveCount, _maxSpawningExplosiveCount);
        
        for (int i = 0; i < spawningExplosiveCount; i++)
        {
            GameObject clone = Instantiate(gameObject, transform.position + Vector3.right, Quaternion.identity);
            clone.GetComponent<Explosive>()._spawnChance /= 2;
            clone.transform.localScale /= 2;
            _colorSeter.SetColor(clone);
        }
    }

    private Collider[] GetColliders()
    {
        return Physics.OverlapSphere(transform.position, _explosionRadius);
    }
}