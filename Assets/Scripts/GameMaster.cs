using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public List<GameObject> prefabList = new List<GameObject>();
    public GameObject border;
    private GameObject go;
    [HideInInspector]
    public GameObject player;

    public Transform spawnPoint;

    public Color ColorCyon;
    public Color ColorYellow;
    public Color ColorGreen;
    public Color ColorPink;

    int index;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0f, 1.2f);
        InvokeRepeating("SpawnBorder", 5.4f, 4.8f);
    }

    // Update is called once per frame
    void Update()
    {
        index = Random.Range(0, prefabList.Count);
    }

    void Spawn()
    {
        go = Instantiate(prefabList[index], spawnPoint.position, Quaternion.identity) as GameObject;

        ColorControl();
        ChooseColor();
    }

    void SpawnBorder()
    {
        go = Instantiate(border, spawnPoint.position, Quaternion.identity) as GameObject;

        ColorControl();
        ChooseColor();
    }

    void ColorControl()
    {
        if (go.transform.childCount == 0)
        {
            return;
        }
        Transform child = go.transform.GetChild(Random.Range(0, go.transform.childCount));

        if (player != null)
        {
            child.gameObject.GetComponent<SpriteRenderer>().color = player.GetComponent<SpriteRenderer>().color;
        }

        if (border != null)
        {
            go.transform.GetChild(Random.Range(0, go.transform.childCount)).GetComponent<SpriteRenderer>().color = border.GetComponent<SpriteRenderer>().color;
        }
    }

    public void ChooseColor()
    {
        foreach (SpriteRenderer colorChange in go.GetComponentsInChildren<SpriteRenderer>())
        {
            int colorIndex = Random.Range(0, 4);

            switch (colorIndex)
            {
                case 0:
                    colorChange.color = ColorCyon;
                    break;
                case 1:
                    colorChange.color = ColorYellow;
                    break;
                case 2:
                    colorChange.color = ColorGreen;
                    break;
                case 3:
                    colorChange.color = ColorPink;
                    break;
            }
        }
    }
}
