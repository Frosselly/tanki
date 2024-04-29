using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class CollectibleTrigger : MonoBehaviour
{
    [SerializeField]
    string medicalPillTag = "Meds";
    [SerializeField]
    string ammoTag = "Ammo";

    [SerializeField, Min(0)]
    int pillValue = 1;

    [SerializeField, Min(0)]
    int ammoValue = 2;

    CollectibleController collectibleController;
    Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
        collectibleController = FindObjectOfType<CollectibleController>();
    }



    private void OnTriggerEnter(Collider other)
    {
        var othGameObj = other.gameObject;
        var collected = false;

        if (IsMedicalPill(othGameObj)){
            collected = true;
            player.AddLives(pillValue);
        }
        if (IsAmmo(othGameObj))
        {
            collected = true;
            player.AddAmmo(ammoValue);
        }

        if (collected)
        {
            othGameObj.SetActive(false);
            Destroy(othGameObj);
            collectibleController.CreateCollectible();
        }
        
    }
    bool IsMedicalPill(GameObject obj)
    {
        return obj.CompareTag(medicalPillTag);
    }
    bool IsAmmo(GameObject obj)
    {
        return obj.CompareTag(ammoTag);
    }
    //
}
