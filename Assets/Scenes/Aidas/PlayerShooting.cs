using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private float shotForce;
    [SerializeField]
    private float shotDistance;
    [SerializeField]
    private int mouseBoundsPercent;
    [SerializeField]
    private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var shot = Instantiate(bullet);
            shot.transform.position = gameObject.transform.position;
            Rigidbody rb = shot.GetComponent<Rigidbody>();

            //
            var mousePos = Input.mousePosition;

            float mouseBoundsMin = Screen.width / 100 * mouseBoundsPercent;
            float mouseBoundsMax = Screen.width - mouseBoundsMin;

            if (mousePos.x < mouseBoundsMin)
                mousePos.x = mouseBoundsMin;
            else if (mousePos.x > mouseBoundsMax)
                mousePos.x = mouseBoundsMax;

            mousePos.y = Mathf.Abs(mousePos.y);
            mousePos.z = shotDistance - Camera.main.transform.position.z;
            var shootVector = Camera.main.ScreenToWorldPoint(mousePos);
            //

            rb.AddForce(shootVector * shotForce);
        }
    }
}
