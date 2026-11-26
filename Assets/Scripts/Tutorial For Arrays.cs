using UnityEngine;

public class TutorialForArrays : MonoBehaviour
{
    void Start()
    {
        string[] languages = new string[5];

        languages[4] = "JavaScript";

        print(languages[4]);
    }
}
