using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private bool isMove = false;
    private int winCount = 0;
    public float speed;

    private Animator animator;
    public static UnityEvent win = new UnityEvent();

    [SerializeField] private int bedCount;

    private void Start()
    {
        Bed.click.AddListener(Move);
        animator = GetComponent<Animator>();
    }

    private void Move(Vector3 position)
    {
        if (!isMove)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(Mathf.Round(position.x - transform.position.x), Mathf.Round(position.y - transform.position.y)));
            if (hit.collider.tag == "Bed" && !hit.collider.GetComponent<Bed>().isSown && (position.x == transform.position.x || position.y == transform.position.y)) StartCoroutine(MovePlayer(position, hit));
        } 
    }

    IEnumerator MovePlayer(Vector2 position, RaycastHit2D hit)
    {
        isMove = true;
        if (Mathf.Round(position.x - transform.position.x) > 0) animator.SetInteger("Side", 3);
        else if (Mathf.Round(position.x - transform.position.x) < 0) animator.SetInteger("Side", 4);
        else if (Mathf.Round(position.y - transform.position.y) > 0) animator.SetInteger("Side", 1);
        else if (Mathf.Round(position.y - transform.position.y) < 0) animator.SetInteger("Side", 2);
        while (transform.position != hit.collider.transform.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, hit.collider.transform.position, speed); 
            yield return null;
        }
        transform.position = hit.collider.transform.position;
        animator.SetInteger("Side", 0);
        winCount++;
        if (winCount == bedCount) win.Invoke();
        isMove = false;
    }
}