using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    //x ve y koordinatlar� i�in alt�genin uzunluk de�erleri
    public float xOffSet = 0.78f;
    public float yOffSet = 0.88f;
    
 
    //sat�r ve s�tun de�erleri
    public int width;
    public int height;
    //hexagon prefab�n�n objesi tan�mlan�yor
    public GameObject hexagonPrefab;
    //olu�turulan hexagonlar� tutacak dizi
    private BackgroundTile[,] allHexagons;
    //background hexagonlar�m�z�n �st�ndeki renkli hexagonlar�n obje dizisi
    public GameObject[] colorfulHexagons;

    public GameObject[,] allColorfulHexagons;

    // Start is called before the first frame update
    void Start()
    {

        allHexagons = new BackgroundTile[width, height];
        allColorfulHexagons = new GameObject[width, height];
        Setup();

    }

    // Update is called once per frame
    void Update()
    {

    }


    //verilen sat�r ve s�tun say�s�na g�re hexagonlar� ekrana yerle�tiren fonksiyon
    private void Setup()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                float yPos = j * yOffSet;


                if (i % 2 == 1)
                {
                    yPos += yOffSet / 2f;
                }

                //Background Hexagonlar
                Vector2 tempPosition = new Vector2((float)(i * xOffSet), (float)(yPos));
                GameObject hexagons = Instantiate(hexagonPrefab, tempPosition, Quaternion.identity) as GameObject;
                hexagons.transform.parent = this.transform;
                hexagons.name = "(" + i + "," + j + ")";


                //Renkli Hexagonlar
                int hexagonToUse = Random.Range(0, colorfulHexagons.Length);
                GameObject colorfulHexagon = Instantiate(colorfulHexagons[hexagonToUse], tempPosition, Quaternion.identity);
                colorfulHexagon.transform.parent = this.transform;
                colorfulHexagon.name = i + "," + j;
                allColorfulHexagons[i, j] = colorfulHexagon;


            }
        }
    }
}
