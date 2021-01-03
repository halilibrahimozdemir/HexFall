using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorfulHexagons : MonoBehaviour
{


    //Komşularını tutacak dizi
    public List<GameObject> neighbours = new List<GameObject>();
    public static List<GameObject> selectedHexagons = new List<GameObject>();
    public GameObject neighbor;



    public static int count;
    public int column;
    public int row;
    public int targetX;
    public int targetY;
    public int x;
    public int y;
    private Board board;
    private GameObject selectedHexagon;
    private GameObject tempHexagon;


    private Vector2 firstTouchPosition;
    private Vector2 tempPosition;
    private Vector2 tempPosition1;
    private Vector2 tempPosition2;


    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();

        x = (int)(transform.position.x/.77f);
        y = (int)(transform.position.y/.87f);
        //bulunulan hexagonun x ve ysini tutuyor
        
        row = targetY;
        column = targetX;
        FindNeighbors();
    }

    // Update is called once per frame
    void Update()
    {
       
      
    }

    private void OnMouseDown()
    {



        firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(firstTouchPosition);

        if (count < 3)
        {
            Select3Pieces();
            //selectedHexagon.GetComponent<Renderer>().material.color =Color.black;
            selectedHexagons.Add(selectedHexagon);
            count++;
            Debug.Log(count);
        }
        else
        {
            Debug.Log("3taneseçtin");
            foreach (GameObject g in selectedHexagons)
            {
                Debug.Log("seçili" + g.name);
            }
            Rotate(selectedHexagons);
        }


    }

    void Select3Pieces()
    {
        selectedHexagon = ClickSelect();


        string name = selectedHexagon.name;

        //Debug.Log("secili"+selectedHexagon.name);

        //isimdeki integerları alıyoruz
        int x = int.Parse(name.Split(',')[0]);
        int y = int.Parse(name.Split(',')[1]);

        //Debug.Log("x" + x + "y" + y);

        // x,y+1   x,y-1   x+1,y   x-1,y   x-1,y-1     x+1,y + 1

        //1

        if (x % 2 == 0)
        {
            if (y + 1 < board.height)
            {

                neighbor = board.allColorfulHexagons[x, y + 1];
                //neighbor.GetComponent<Renderer>().material.color = Color.black;
                neighbours.Add(neighbor);

            }


            //Debug.Log("komşu:" + neighbor.name);

            //2
            if (y - 1 >= 0)
            {
                neighbor = board.allColorfulHexagons[x, y - 1];
                //neighbor.GetComponent<Renderer>().material.color = Color.black;
                neighbours.Add(neighbor);
            }

            if (x + 1 < board.width)
            {
                neighbor = board.allColorfulHexagons[x + 1, y];
                //neighbor.GetComponent<Renderer>().material.color = Color.black;
                neighbours.Add(neighbor);
            }

            if (x - 1 >= 0)
            {
                neighbor = board.allColorfulHexagons[x - 1, y];
                //neighbor.GetComponent<Renderer>().material.color = Color.black;
                neighbours.Add(neighbor);
            }

            if (x + 1 < board.width && y - 1 >= 0)
            {
                neighbor = board.allColorfulHexagons[x + 1, y - 1];
                //neighbor.GetComponent<Renderer>().material.color = Color.black;
                neighbours.Add(neighbor);
            }

            //6
            if (x - 1 >= 0 && y - 1 >= 0)
            {
                neighbor = board.allColorfulHexagons[x - 1, y - 1];
                //neighbor.GetComponent<Renderer>().material.color = Color.black;
                neighbours.Add(neighbor);
            }
        }
        else
        {
            if (y + 1 < board.height)
            {

                neighbor = board.allColorfulHexagons[x, y + 1];
                //neighbor.GetComponent<Renderer>().material.color = Color.black;
                neighbours.Add(neighbor);
            }

                        //Debug.Log("komşu:" + neighbor.name);

            //2
            if (y - 1 >= 0)
            {
                neighbor = board.allColorfulHexagons[x, y - 1];
                //neighbor.GetComponent<Renderer>().material.color = Color.black;
                
                neighbours.Add(neighbor);
            }

            if (x + 1 < board.width)
            {
                neighbor = board.allColorfulHexagons[x + 1, y];
                //neighbor.GetComponent<Renderer>().material.color = Color.black;
                neighbours.Add(neighbor);
            }

            if (x - 1 >= 0)
            {
                neighbor = board.allColorfulHexagons[x - 1, y];
                //neighbor.GetComponent<Renderer>().material.color = Color.black;
                neighbours.Add(neighbor);
            }

            if (x + 1 < board.width && y + 1 < board.height)
            {
                neighbor = board.allColorfulHexagons[x + 1, y + 1];
                //neighbor.GetComponent<Renderer>().material.color = Color.black;
                neighbours.Add(neighbor);
            }

            //6
            if (x - 1 >= 0 && y + 1 < board.height)
            {
                neighbor = board.allColorfulHexagons[x - 1, y + 1];
                //neighbor.GetComponent<Renderer>().material.color = Color.black;
                neighbours.Add(neighbor);
            }

        }
                              
    }
    GameObject ClickSelect()
    {
        //Converting $$anonymous$$ouse Pos to 2D (vector2) World Pos
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);


        if (hit)
        {
            //Debug.Log(hit.transform.name);
            return hit.transform.gameObject;
        }
        else return null;


    }

    void Rotate(List<GameObject> objects)
    {
        tempPosition = new Vector2(objects[0].transform.position.x, objects[0].transform.position.y);
        tempPosition1 = new Vector2(objects[1].transform.position.x, objects[1].transform.position.y);
        tempPosition2 = new Vector2(objects[2].transform.position.x, objects[2].transform.position.y);

        objects[1].transform.position = tempPosition;
        objects[2].transform.position = tempPosition1;
        objects[0].transform.position = tempPosition2;

              
        //Debug.Log("yer değiştirildi");
    }


    void FindNeighbors()
    {


        //Debug.Log("x" + x + "y" + y);

        // x,y+1   x,y-1   x+1,y   x-1,y   x-1,y-1     x+1,y + 1

        //1

        if (x % 2 == 0)
        {
            if (y + 1 < board.height && x + 1 < board.width && x + 1 < board.width)
            {
                if (board.allColorfulHexagons[x, y + 1].tag ==
                this.gameObject.tag &&
                board.allColorfulHexagons[x + 1, y].tag ==
                this.gameObject.tag)
                {

                    this.gameObject.name = "destroy";

                }



            }


            //Debug.Log("komşu:" + neighbor.name);

            //2
            if (x + 1 < board.width && y - 1 >= 0)
            {
                if (board.allColorfulHexagons[x + 1, y].tag ==
                this.gameObject.tag &&
                board.allColorfulHexagons[x + 1, y - 1].tag ==
                this.gameObject.tag)
                {

                    this.gameObject.name = "destroy";


                }

            }

            if (x + 1 < board.width && y - 1 >= 0)
            {
                if (board.allColorfulHexagons[x + 1, y - 1].tag ==
                  this.gameObject.tag &&
                  board.allColorfulHexagons[x, y - 1].tag ==
                  this.gameObject.tag)
                {

                    this.gameObject.name = "destroy";


                }
            }

            if (y - 1 >= 0 && x - 1 >= 0)
            {
                if (board.allColorfulHexagons[x, y - 1].tag ==
                 this.gameObject.tag &&
                 board.allColorfulHexagons[x - 1, y - 1].tag ==
                 this.gameObject.tag)
                {

                    this.gameObject.name = "destroy";


                }
            }

            if (x - 1 >= 0 && y - 1 >= 0 && y + 1 <= board.height)
            {
                if (board.allColorfulHexagons[x - 1, y - 1].tag ==
                this.gameObject.tag &&
                board.allColorfulHexagons[x - 1, y + 1].tag ==
                this.gameObject.tag)
                {

                    this.gameObject.name = "destroy";


                }
            }

            //6
            if (x - 1 >= 0 && y + 1 < board.height)
            {
                if (board.allColorfulHexagons[x - 1, y + 1].tag ==
                 this.gameObject.tag &&
                 board.allColorfulHexagons[x, y + 1].tag ==
                 this.gameObject.tag)
                {

                    this.gameObject.name = "destroy";


                }
            }
        }
        else
        {
            if (y + 1 < board.height && x + 1 < board.width )
            {
                if (board.allColorfulHexagons[x, y + 1].tag ==
                this.gameObject.tag &&
                board.allColorfulHexagons[x + 1, y+1].tag ==
                this.gameObject.tag)
                {

                    this.gameObject.name = "destroy";

                }
            


            }


            //Debug.Log("komşu:" + neighbor.name);

            //2
            if (y + 1 < board.height && x + 1 < board.width)
            {
                if (board.allColorfulHexagons[x + 1, y+1].tag ==
                this.gameObject.tag &&
                board.allColorfulHexagons[x + 1, y].tag ==
                this.gameObject.tag)
                {

                    this.gameObject.name = "destroy";


                }

            }

            if (x + 1 < board.width &&  y - 1 >= 0)
            {
                if (board.allColorfulHexagons[x + 1, y].tag ==
                  this.gameObject.tag &&
                  board.allColorfulHexagons[x, y - 1].tag ==
                  this.gameObject.tag)
                {

                    this.gameObject.name = "destroy";


                }
            }

            if (y - 1 >= 0 && x - 1 >= 0)
            {
                if (board.allColorfulHexagons[x, y - 1].tag ==
                 this.gameObject.tag &&
                 board.allColorfulHexagons[x - 1, y].tag ==
                 this.gameObject.tag)
                {

                    this.gameObject.name = "destroy";


                }
            }

            if (x - 1 >= 0 && y + 1 <= board.height)
            {
                if (board.allColorfulHexagons[x - 1, y].tag ==
                this.gameObject.tag &&
                board.allColorfulHexagons[x - 1, y + 1].tag ==
                this.gameObject.tag)
                {

                    this.gameObject.name = "destroy";


                }
            }

            //6
            if (x - 1 >= 0 && y + 1 < board.height)
            {
                if (board.allColorfulHexagons[x - 1, y + 1].tag ==
                 this.gameObject.tag &&
                 board.allColorfulHexagons[x, y + 1].tag ==
                 this.gameObject.tag)
                {

                    this.gameObject.name = "destroy";


                }
            }
        }
        
                     
    }
}
