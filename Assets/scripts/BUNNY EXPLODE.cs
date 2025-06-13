using UnityEngine;
using UnityEngine.UI;

public class BUNNYEXPLODE : MonoBehaviour
{
    public float explosionRadius = 20f;
    public float explosionForce = 10f;

    public ParticleSystem particleSystem;
    public Button explodeButton;

    public bool hasExploded = false;
    public void Explode()
    {
        if (hasExploded) return;
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb == null || rb.isKinematic) continue;
            if (rb.gameObject == gameObject) continue;

            Vector3 direction = rb.transform.position - transform.position;
            rb.AddForce(direction.normalized * explosionForce / direction.magnitude, ForceMode.Impulse);
        }
        particleSystem.Play();
        hasExploded = true;
        UpdateButton();
    }

    public void UpdateButton()
    {
        explodeButton.interactable = !hasExploded;
    }
}