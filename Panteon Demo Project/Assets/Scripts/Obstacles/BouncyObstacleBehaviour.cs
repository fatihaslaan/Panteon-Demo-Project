using UnityEngine;

public class BouncyObstacleBehaviour : MonoBehaviour
{
    float timerToActivateCollider = 0f;

    void Update()
    {
        if (timerToActivateCollider < 0)
        {
            GetComponent<BoxCollider>().enabled = true; //To prevent collide more than once for a while
            timerToActivateCollider = 0f;
        }
        else
            timerToActivateCollider -= Time.deltaTime;
    }
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Character")
        {
            GetComponent<BoxCollider>().enabled = false;
            Vector3 dir = c.transform.position - transform.position;
            dir = new Vector3(dir.x / 5, 0, dir.z > 0 ? dir.z * 5 : dir.z * 12); //Push more to backwards
            float force = 340f;
            force *= Vector3.Distance(transform.parent.position, c.transform.position); //Push more if character is far
            c.gameObject.GetComponent<Rigidbody>().AddForce(dir * force);
            timerToActivateCollider = 0.2f;
        }
    }
}