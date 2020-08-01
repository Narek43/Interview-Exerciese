using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersonalPageManager : MonoBehaviour
{
    [SerializeField]
    private Image point;
    [SerializeField]
    private Transform parent;
    [SerializeField]
    private int pointsCount;
    [SerializeField]
    private GameObject atlas;
    [SerializeField]
    private TextMeshProUGUI name;
    private Image[] points;
    bool isOpened = false;

    // Create points using the prefab.
    void Start()
    {
        points = new Image[pointsCount];

        points[0] = Instantiate(point, parent);
        RectTransform rT0 = points[0].GetComponent<RectTransform>();
        rT0.anchorMin = new Vector2(0.475f, 0.4885f);
        rT0.anchorMax = new Vector2(0.525f, 0.5115f);
        points[0].GetComponent<Image>().color = new Color32(0, 60, 225, 255);

        for (int i = 1; i < pointsCount; i++)
        {
            float x, y;
            x = Random.Range(0.05f, 0.9f);
            y = Random.Range(0.15f, 0.85f);
            points[i] = Instantiate(point, parent);
            RectTransform rT = points[i].GetComponent<RectTransform>();
            rT.anchorMin = new Vector2(x, y);
            rT.anchorMax = new Vector2(x + 0.05f, y + 0.023f);
        }

    }

    // To find nearest point, and to make it green.
    public void NearestPointFinder()
    {
        Vector2 locationPos = points[0].GetComponent<RectTransform>().transform.position;
        Vector2 lastPointPos = points[1].GetComponent<RectTransform>().transform.position;
        Image nearestPoint = points[1];
        for(int i=2; i<pointsCount; i++)
        {
            Vector2 pointPos = points[i].GetComponent<RectTransform>().transform.position;
            if ((locationPos - pointPos).magnitude < (locationPos - lastPointPos).magnitude)
            {
                nearestPoint = points[i];
                lastPointPos = pointPos;
            }
        }
        nearestPoint.GetComponent<Image>().color = new Color32(0, 255, 22, 255);
    }

    // To open and to close personal information atlas.
    public void AtlasHandler()
    {
        Vector2 openedPosMin = new Vector2(0.05f, 0.13f);
        Vector2 openedPosMax = new Vector2(0.95f, 0.865f);
        Vector2 closedPosMin = new Vector2(0.05f, 0.87f);
        Vector2 closedPosMax = new Vector2(0.95f, 1.6f);
        if(isOpened)
        {
            atlas.GetComponent<RectTransform>().anchorMin = closedPosMin;
            atlas.GetComponent<RectTransform>().anchorMax = closedPosMax;
            isOpened = false;
        }
        else
        {
            atlas.GetComponent<RectTransform>().anchorMin = openedPosMin;
            atlas.GetComponent<RectTransform>().anchorMax = openedPosMax;
            name.GetComponent<TextMeshProUGUI>().text = DataManager.UserName;
            isOpened = true;
        }
    }

    public void SignOut()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
