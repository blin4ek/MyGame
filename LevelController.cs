using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private Sprite sowBed;
    [SerializeField] private SpriteRenderer player;
    [SerializeField] private GameObject button;

    private DataTimeLevel data = new DataTimeLevel();

    private float prevPosY;

    private bool isFirstStart => PlayerPrefs.GetInt("FirstStart") == 1;

    private void Start()
    {
        if (isFirstStart)
        {
            data = JsonUtility.FromJson<DataTimeLevel>(PlayerPrefs.GetString("TimeLevel"));
            int levels = PlayerPrefs.GetInt("OpenLevels");
            for (int i = 0; i < levels; i++)
            {
                buttons[i].interactable = true;
                if (isFirstStart) buttons[i].GetComponentInChildren<Text>().text = data.timeLevel[i].ToString("000");
                if (i != levels - 1) buttons[i].image.sprite = sowBed;
            }
            if (levels > 7)
            {
                button.transform.position = new Vector3(button.transform.position.x, player.transform.position.y, button.transform.position.z);
            }
            if (levels > 0) player.transform.position = buttons[levels - 1].transform.position;
        }
        else
        {
            PlayerPrefs.SetString("TimeLevel", JsonUtility.ToJson(data));
            PlayerPrefs.SetInt("OpenLevels", 1);
            PlayerPrefs.SetInt("FirstStart", 1);
        }    
    }

    private void OnMouseDrag()
    {
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y > prevPosY && button.transform.position.y < -1f) button.transform.position = new Vector3(button.transform.position.x, button.transform.position.y + (Camera.main.ScreenToWorldPoint(Input.mousePosition).y - prevPosY), button.transform.position.z);
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y < prevPosY && button.transform.position.y > -15f) button.transform.position = new Vector3(button.transform.position.x, button.transform.position.y - (prevPosY - Camera.main.ScreenToWorldPoint(Input.mousePosition).y), button.transform.position.z);
        prevPosY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
    }

    private void OnMouseDown()
    {
        prevPosY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
    }
} 