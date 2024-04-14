using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musciaLoop : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        GameObject[] musica = GameObject.FindGameObjectsWithTag("musica");
        if (musica.Length > 1) {
            Destroy(musica[0]);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
