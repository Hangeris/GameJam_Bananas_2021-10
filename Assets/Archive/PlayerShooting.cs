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
    [SerializeField]
    private Transform shootingPos;
    [SerializeField]
    private AudioClip[] audioClips;

    private AudioSource audioSource;
    private Animator anim;
    private bool shoot = false;

    private static readonly int Throw = Animator.StringToHash("Throw");

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shoot = true;
        }
    }

    void FixedUpdate()
    {
        if (shoot)
        {
            shoot = false;
            
            var shot = Instantiate(bullet, shootingPos.position, Quaternion.identity);
            Rigidbody rb = shot.GetComponent<Rigidbody>();

            anim.SetTrigger(Throw);

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

            rb.AddForce((shootVector - shootingPos.transform.position) * shotForce);
            rb.AddTorque(new Vector3(10000f, 0 ,0), ForceMode.Force);
            int audioClipIndex = Random.Range(0, audioClips.Length);
            audioSource.PlayOneShot(audioClips[audioClipIndex]);
            
            Destroy(shot, 3f);
        }
    }
}
