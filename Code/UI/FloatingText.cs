using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
sealed public class FloatingText : MonoBehaviour
{
    public float destroyTime = 1f;
    public Vector2 random = new Vector2(0.5f, 0.5f);
    public TMP_Text damageText;

    private void Awake()
    {
        damageText = GetComponent<TMP_Text>();

        transform.localPosition += Vector3.up;
        transform.localPosition += new Vector3( Random.Range(-random.x, random.y),

        Random.Range(-random.x, random.y), 0 );
        Destroy(gameObject, destroyTime);
    }
    private void Update() => Move();
    private void Move()
    {
        transform.localPosition += Vector3.up * Time.deltaTime;
        transform.localPosition += new Vector3( Mathf.Sin(Time.time), Mathf.Sin(Time.time)) * Time.deltaTime;
    } 
}