using UnityEngine;

public class grenade : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private string ignoreTagName;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        rb.linearVelocity = transform.up.normalized * 1.60f;
        Destroy(gameObject, 2f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag(ignoreTagName))
        {
            IDemageble damageable = collision.gameObject.GetComponent<IDemageble>();

            if (damageable != null)
            {
                damageable.TakeDamage(1);
                Destroy(gameObject);
            }
        }
    }
}
