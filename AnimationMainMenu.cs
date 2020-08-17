using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMainMenu : MonoBehaviour
{
    [SerializeField] private Sprite[] spritesPlayer;
    [SerializeField] private SpriteRenderer player;
    [SerializeField] private SpriteRenderer flower;
    [SerializeField] private Sprite[] flowers;
    [SerializeField] private SpriteRenderer grass;
    private List<SpriteRenderer> listFlowers = new List<SpriteRenderer>();

    private void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(MovePlayer());
        StartCoroutine(SpawnFlowers());
    }

    IEnumerator SpawnFlowers()
    {
        while (true)
        {
            SpriteRenderer temp = Instantiate(flower, new Vector3(Random.Range(-10f, 10f), flower.transform.position.y, 0), Quaternion.identity);
            temp.sprite = flowers[Random.Range(0,4)];
            listFlowers.Add(temp);
            Destroy(temp, 11);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void FixedUpdate()
    {
        foreach (var item in listFlowers)
        {
            if (item != null) item.transform.position += Vector3.up * Time.deltaTime * 2;
        }
        grass.material.mainTextureOffset -= new Vector2(0, Time.deltaTime * 3.4f);
    }

    IEnumerator MovePlayer()
    {
        while (true)
        {
            for (int i = 0; i < 2; i++)
            {
                player.sprite = spritesPlayer[i];
                yield return new WaitForSeconds(0.3f);
            }
        }
    }
}