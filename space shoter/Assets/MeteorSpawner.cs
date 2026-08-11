using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [Header("Meteor Secenekleri")]
    public GameObject[] meteorPrefableri;

    [Header("Zaman Ayarlari")]
    public float minimumDogmaSuresi = 0.5f;
    public float maksimumDogmaSuresi = 2f;

    [Header("Konum Ayarlari")]
    public float xUretimSiniri = 8f;
    public float yUretimYuksekligi = 6f;

    void Start()
    {
        StartCoroutine(MeteorUreticiDongu());
    }

    IEnumerator MeteorUreticiDongu()
    {
        while (true)
        {
            float beklemeSuresi = Random.Range(minimumDogmaSuresi, maksimumDogmaSuresi);
            yield return new WaitForSeconds(beklemeSuresi);

            if (meteorPrefableri == null || meteorPrefableri.Length == 0) continue;

            int rastgeleIndeks = Random.Range(0, meteorPrefableri.Length);
            GameObject secilenMeteor = meteorPrefableri[rastgeleIndeks];

            float rastgeleX = Random.Range(-xUretimSiniri, xUretimSiniri);
            Vector3 uretimKonumu = new Vector3(rastgeleX, yUretimYuksekligi, 0f);

            Instantiate(secilenMeteor, uretimKonumu, Quaternion.identity);
        }
    }
}