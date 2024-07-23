using UnityEngine;

public class Init : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<ViewManager>().PlayScene("Gameplay");
    }
}
