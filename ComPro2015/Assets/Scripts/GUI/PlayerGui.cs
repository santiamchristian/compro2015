using UnityEngine;
using System.Collections;



public class PlayerGui : MonoBehaviour
{

    public Transform playerContainer;
    public RectTransform[] guiPositions = new RectTransform[5];
    private int previousPlayerCount = 0;
    public RectTransform[] guiPrefabs = new RectTransform[4];

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        previousPlayerCount = playerContainer.transform.childCount;
    }

    public RectTransform AddPlayer(int index, ElementEnum element)
    {
        RectTransform newGui = Instantiate(guiPrefabs[(int)element]) as RectTransform;
        newGui.position = guiPositions[index].position;
        newGui.parent = guiPositions[index];
        return newGui;

    }
}
