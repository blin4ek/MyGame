using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
    private string gameId = "3707741";
    private static int counter = 0;

    void Start()
    {
        Advertisement.Initialize(gameId, false);
        StartCoroutine(ShowBanner());
    }

    IEnumerator ShowBanner()
    {
        while (!Advertisement.IsReady("Banner"))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show("Banner");
    }

    public static void ShowAds()
    {
        counter++;
        if (counter == 3) { Advertisement.Show("video"); counter = 0; }
    }
}