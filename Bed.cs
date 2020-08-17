using UnityEngine;
using UnityEngine.Events;

public class Bed : MonoBehaviour
{
    [SerializeField] private Sprite sown;
    public static MyEvent click = new MyEvent();
    public bool isSown = false;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        click.Invoke(transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") { sprite.sprite = sown; isSown = true; }
    }
}

public class MyEvent : UnityEvent<Vector3>
{ }
