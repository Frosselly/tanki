
using System.Collections.Generic;
using UnityEngine;

public class AntiMineTrigger : MonoBehaviour
{

    [SerializeField]
    string antiTankMineTag = "ATMine";

    [SerializeField]
    float minExplosionForce = 3.0f;

    [SerializeField]
    float maxExplosionForce = 5f;

    AntiTankMineController antiTankMineController;
    Rigidbody rb;
    Player player;

    private void Awake()
    {
        antiTankMineController = FindObjectOfType<AntiTankMineController>();
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var otherGameObject = collision.gameObject;
        if(IsAntiTankMine(otherGameObject))
        {
            AddExplosionForce();
            otherGameObject.SetActive(false);
            Destroy(otherGameObject);
            player.TakeDamage();
            antiTankMineController.CreateMine();
        }
    }

    private bool IsAntiTankMine(GameObject obj)
    {
        return obj.CompareTag(antiTankMineTag);
    }

    private void AddExplosionForce()
    {
        var force = Random.Range(minExplosionForce, maxExplosionForce);
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }

    
}
