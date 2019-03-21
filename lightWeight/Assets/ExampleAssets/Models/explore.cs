using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explore : MonoBehaviour {
    public float power, blastRadius, distance = 1f;
    public LayerMask explosionLayer;
    private Collider[] hitColliders;
    int timer = 0;

    void FixedUpdate()
    {
        RaycastHit hit = new RaycastHit();

        Ray srcRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetButton("Fire1") && Physics.Raycast(srcRay, out hit))
        {
            timer++;
            if (timer < 4)
            {
                Debug.Log(timer);
                Explosion(hit.point);
                timer = 0;
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            timer = 0;
        }
    }

    void Explosion(Vector3 point)
    {
        hitColliders = Physics.OverlapSphere(point, blastRadius, explosionLayer);

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.GetComponent<Rigidbody>() != null)
            {
                hitCollider.GetComponent<Rigidbody>().isKinematic = false;
                hitCollider.GetComponent<Rigidbody>().AddExplosionForce(power, point, blastRadius);
            }
        }
    }
    
}
