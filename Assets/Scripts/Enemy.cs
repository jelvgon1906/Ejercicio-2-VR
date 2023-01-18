using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject stone;
    public Transform shootPoint;
    public float shootForce;
    bool playerDetected;
    public float cadency;
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            StartCoroutine("Attack");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            StopCoroutine("Attack");
        }
    }

    public IEnumerator Attack()
    {
        while (true)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("player").transform);
            yield return new WaitForSeconds(0.2f);
            /*GetComponent<Animator>()*/animator.Play("Attack");
            yield return new WaitForSeconds(cadency);
        }
    }

    public void Shoot()
    {
        Instantiate(stone, shootPoint.position, shootPoint.rotation).GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce);
    }
}
