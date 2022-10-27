using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DamageOnContact : MonoBehaviour
{
    
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);

        Life life = other.GetComponent<Life>();
        if (life != null)
        {
            life.Amount -= damage;
        }
    }
}
