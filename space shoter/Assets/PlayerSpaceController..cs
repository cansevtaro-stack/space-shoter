using UnityEngine;

public class PlayerSpaceController : MonoBehaviour
{
    [Header("Hareket Ayarlari")]
    public float hareketHizi = 10f;

    [Header("Ates Ayarlari")]
    public GameObject mermiPrefab;
    public Transform atesNoktasi;
    public float mermiHizi = 15f;

    private Rigidbody2D rb;
    private Vector2 hareketGirdisi;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float yatay = Input.GetAxisRaw("Horizontal");
        float dikey = Input.GetAxisRaw("Vertical");

        hareketGirdisi = new Vector2(yatay, dikey).normalized;

        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            AtesEt();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = hareketGirdisi * hareketHizi;
    }

    void AtesEt()
    {
        if (mermiPrefab != null && atesNoktasi != null)
        {
            GameObject yeniMermi = Instantiate(mermiPrefab, atesNoktasi.position, Quaternion.identity);
            Rigidbody2D mermiRb = yeniMermi.GetComponent<Rigidbody2D>();
            mermiRb.velocity = Vector2.up * mermiHizi;
            Destroy(yeniMermi, 3f);
        }
    }
}


