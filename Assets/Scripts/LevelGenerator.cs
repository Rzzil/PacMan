using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //0 – Empty(do not instantiate anything)
    //1 - Outside corner(double lined corener piece in orginal game)
    //2 - Outside wall(double line in original game)
    //3 - Inside corner(single lined corener piece in orginal game)
    //4 - Inside wall(single line in orginal game)
    //5 - Standard pellet(see Visual Assets above)
    //6 - Power pellet(see Visual Assets above)
    //7 - A t junction piece for connecting with adjoining regions
    private int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7,2,2,2,2,2,2,2,2,2,2,2,2,1},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4,5,5,5,5,5,5,5,5,5,5,5,5,2},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4,5,3,4,4,4,3,5,3,4,4,3,5,2},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4,5,4,0,0,0,4,5,4,0,0,4,6,2},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3,5,3,4,4,4,3,5,3,4,4,3,5,2},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3,4,4,3,5,4,4,5,3,4,4,3,5,2},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4,5,5,5,5,4,4,5,5,5,5,5,5,2},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4,0,3,4,4,3,4,5,1,2,2,2,2,1},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3,0,3,4,4,3,4,5,2,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0,4,4,3,0,4,4,5,2,0,0,0,0,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0,0,0,4,0,0,0,5,0,0,0,0,0,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0,4,4,3,0,4,4,5,2,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3,0,3,4,4,3,4,5,2,0,0,0,0,0},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4,0,3,4,4,3,4,5,1,2,2,2,2,1},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4,5,5,5,5,4,4,5,5,5,5,5,5,2},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3,4,4,3,5,4,4,5,3,4,4,3,5,2},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3,5,3,4,4,4,3,5,3,4,4,3,5,2},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4,5,4,0,0,0,4,5,4,0,0,4,6,2},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4,5,3,4,4,4,3,5,3,4,4,3,5,2},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4,5,5,5,5,5,5,5,5,5,5,5,5,2},
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7,2,2,2,2,2,2,2,2,2,2,2,2,1},
    };

    [SerializeField]
    private List<GameObject> assetsList;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < levelMap.GetLength(0); i++)
        {
            for (int j = 0; j < levelMap.GetLength(1); j++)
            {
                switch (levelMap[i, j])
                {
                    case 1:
                        if (j + 1 < levelMap.GetLength(1) && i + 1 < levelMap.GetLength(0) && (levelMap[i, j + 1] == 2 || levelMap[i, j + 1] == 1) && (levelMap[i + 1, j] == 2 || levelMap[i + 1, j] == 1))
                        {
                            Instantiate(assetsList[0], new Vector2(0.55f * j, -0.55f * i), Quaternion.identity);
                        }
                        else if (j - 1 >= 0 && i + 1 < levelMap.GetLength(0) && (levelMap[i, j - 1] == 2 || levelMap[i, j - 1] == 1) && (levelMap[i + 1, j] == 2 || levelMap[i + 1, j] == 1))
                        {
                            Instantiate(assetsList[0], new Vector2(0.55f * j, -0.55f * i), Quaternion.Euler(0, 0, -90));
                        }
                        else if (j + 1 < levelMap.GetLength(1) && i - 1 >= 0 && (levelMap[i, j + 1] == 2 || levelMap[i, j + 1] == 1) && (levelMap[i - 1, j] == 2 || levelMap[i - 1, j] == 1))
                        {
                            Instantiate(assetsList[0], new Vector2(0.55f * j, -0.55f * i), Quaternion.Euler(0, 0, 90));
                        }
                        else if (j - 1 >= 0 && i - 1 >= 0 && (levelMap[i, j - 1] == 2 || levelMap[i, j - 1] == 1) && (levelMap[i - 1, j] == 2 || levelMap[i - 1, j] == 1))
                        {
                            Instantiate(assetsList[0], new Vector2(0.55f * j, -0.55f * i), Quaternion.Euler(0, 0, 180));
                        }
                        break;
                    case 2:
                        if ((i + 1 < levelMap.GetLength(0) && (levelMap[i + 1, j] == 1 || levelMap[i + 1, j] == 2)) || (i - 1 >= 0 && (levelMap[i - 1, j] == 1 || levelMap[i - 1, j] == 2)))
                        {
                            Instantiate(assetsList[1], new Vector2(0.55f * j, -0.55f * i), Quaternion.Euler(0, 0, 90));
                        }
                        else if ((j + 1 < levelMap.GetLength(1) && (levelMap[i, j + 1] == 1 || levelMap[i, j + 1] == 2)) || (j - 1 >= 0 && (levelMap[i, j - 1] == 1 || levelMap[i, j - 1] == 2)))
                        {
                            Instantiate(assetsList[1], new Vector2(0.55f * j, -0.55f * i), Quaternion.identity);
                        }
                        break;
                    case 3:
                        GameObject temp1 = null;
                        if ((j + 1 < levelMap.GetLength(1) && (levelMap[i, j + 1] == 3 || levelMap[i, j + 1] == 4)) && (j - 1 >= 0 && (levelMap[i, j - 1] == 3 || levelMap[i, j - 1] == 4)) && (i + 1 < levelMap.GetLength(0) && (levelMap[i + 1, j] == 3 || levelMap[i + 1, j] == 4)) && (i - 1 >= 0 && (levelMap[i - 1, j] == 3 || levelMap[i - 1, j] == 4)))
                        {
                            if (levelMap[i + 1, j + 1] == 5 || levelMap[i + 1, j + 1] == 6)
                            {
                                temp1 = Instantiate(assetsList[2], new Vector2(0.55f * j, -0.55f * i), Quaternion.identity);
                            }
                            else if (levelMap[i - 1, j + 1] == 5 || levelMap[i - 1, j + 1] == 6 || levelMap[i - 1, j + 1] == 0)
                            {
                                temp1 = Instantiate(assetsList[2], new Vector2(0.55f * j, -0.55f * i), Quaternion.Euler(0, 0, 90));
                            }
                            else if (levelMap[i + 1, j - 1] == 5 || levelMap[i + 1, j - 1] == 6 || levelMap[i + 1, j - 1] == 0)
                            {
                                temp1 = Instantiate(assetsList[2], new Vector2(0.55f * j, -0.55f * i), Quaternion.Euler(0, 0, -90));
                            }
                            else if (levelMap[i - 1, j - 1] == 5 || levelMap[i - 1, j - 1] == 6 || levelMap[i - 1, j - 1] == 0)
                            {
                                temp1 = Instantiate(assetsList[2], new Vector2(0.55f * j, -0.55f * i), Quaternion.Euler(0, 0, 180));
                            }
                        }
                        if (temp1 == null && j + 1 < levelMap.GetLength(1) && i + 1 < levelMap.GetLength(0) && (levelMap[i, j + 1] == 4 || levelMap[i, j + 1] == 3) && (levelMap[i + 1, j] == 4 || levelMap[i + 1, j] == 3))
                        {
                            Instantiate(assetsList[2], new Vector2(0.55f * j, -0.55f * i), Quaternion.identity);
                        }
                        else if (temp1 == null && j - 1 >= 0 && i + 1 < levelMap.GetLength(0) && (levelMap[i, j - 1] == 4 || levelMap[i, j - 1] == 3) && (levelMap[i + 1, j] == 4 || levelMap[i + 1, j] == 3))
                        {
                            Instantiate(assetsList[2], new Vector2(0.55f * j, -0.55f * i), Quaternion.Euler(0, 0, -90));
                        }
                        else if (temp1 == null && j + 1 < levelMap.GetLength(1) && i - 1 >= 0 && (levelMap[i, j + 1] == 4 || levelMap[i, j + 1] == 3) && (levelMap[i - 1, j] == 4 || levelMap[i - 1, j] == 3))
                        {
                            Instantiate(assetsList[2], new Vector2(0.55f * j, -0.55f * i), Quaternion.Euler(0, 0, 90));
                        }
                        else if (temp1 == null && j - 1 >= 0 && i - 1 >= 0 && (levelMap[i, j - 1] == 4 || levelMap[i, j - 1] == 3) && (levelMap[i - 1, j] == 4 || levelMap[i - 1, j] == 3))
                        {
                            Instantiate(assetsList[2], new Vector2(0.55f * j, -0.55f * i), Quaternion.Euler(0, 0, 180));
                        }
                        break;
                    case 4:
                        GameObject temp2 = null;
                        if ((i + 1 < levelMap.GetLength(0) && (levelMap[i + 1, j] == 3 || levelMap[i + 1, j] == 4)) && (i - 1 >= 0 && (levelMap[i - 1, j] == 3 || levelMap[i - 1, j] == 4)))
                        {
                            temp2 = Instantiate(assetsList[3], new Vector2(0.55f * j, -0.55f * i), Quaternion.Euler(0, 0, 90));
                        }
                        else if ((j + 1 < levelMap.GetLength(1) && (levelMap[i, j + 1] == 3 || levelMap[i, j + 1] == 4)) && (j - 1 >= 0 && (levelMap[i, j - 1] == 3 || levelMap[i, j - 1] == 4)))
                        {
                            temp2 = Instantiate(assetsList[3], new Vector2(0.55f * j, -0.55f * i), Quaternion.identity);
                        }
                        if (temp2 == null && ((j + 1 < levelMap.GetLength(1) && (levelMap[i, j + 1] == 3 || levelMap[i, j + 1] == 4)) || (j - 1 >= 0 && (levelMap[i, j - 1] == 3 || levelMap[i, j - 1] == 4))))
                        {
                            temp2 = Instantiate(assetsList[3], new Vector2(0.55f * j, -0.55f * i), Quaternion.identity);
                        }
                        else if (temp2 == null && ((i + 1 < levelMap.GetLength(0) && (levelMap[i + 1, j] == 3 || levelMap[i + 1, j] == 4)) || (i - 1 >= 0 && (levelMap[i - 1, j] == 3 || levelMap[i - 1, j] == 4))))
                        {
                            temp2 = Instantiate(assetsList[3], new Vector2(0.55f * j, -0.55f * i), Quaternion.Euler(0, 0, 90));
                        }
                        break;
                    case 5:
                        Instantiate(assetsList[4], new Vector2(0.55f * j, -0.55f * i), Quaternion.identity);
                        break;
                    case 6:
                        Instantiate(assetsList[5], new Vector2(0.55f * j, -0.55f * i), Quaternion.identity);
                        break;
                    case 7:
                        Instantiate(assetsList[6], new Vector2(0.55f * j, -0.55f * i), Quaternion.identity);
                        break;
                    default:
                        break;
                }
            }
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
