using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tile { question_mark = 27, _ = 0, A = 1, B = 2, C = 3, D = 4, E = 5, F = 6, G = 7, H = 8, I = 9, J = 10, K = 11, L = 12, M = 13, N = 14, O = 15, P = 16, Q = 17, R = 18, S = 19, T = 20, U = 21, V = 22, W = 23, X = 24, Y = 25, Z = 26 }


public class WordHandler : MonoBehaviour {


    public GameObject letter_tile_prefab;
    public GameObject LetterPrefab;
    public GameObject letter_crate_prefab;
    public static WordHandler instance;
    public Texture2D[] lettertile_textures;

    public static int[] points = new int[]{ 0, 1, 3, 3, 2, 1, 4, 2, 4, 1, 8, 5, 1, 3, 1, 1, 3, 10, 1, 1, 1, 1, 4, 4, 8, 4, 10, 0 };
    public static Tile[] chance = new Tile[] { Tile.J, Tile.K, Tile.Q, Tile.X, Tile.Z, Tile.B, Tile.C, Tile.F, Tile.H, Tile.M, Tile.P, Tile.V, Tile.W, Tile.Y, Tile.G, Tile.D, Tile.L, Tile.S, Tile.U, Tile.N, Tile.R, Tile.T, Tile.O, Tile.A, Tile.I, Tile.E };
    public int total_tiles = 98;

    List<string> words_3;
    List<string> words_4;
    List<string> words_5;
    List<string> words_6;
    List<string> words_7;
    public TextAsset text2;

    private void Awake()
    {
        if (WordHandler.instance == null)
            WordHandler.instance = this;
        else if (WordHandler.instance != this)
            Destroy(this.gameObject);
        words_3 = new List<string>();
        words_4 = new List<string>();
        words_5 = new List<string>();
        words_6 = new List<string>();
        words_7 = new List<string>();

        string[] text = text2.ToString().Split(new char[]{'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < text.Length; i++)
        {
            switch (text[i].Length)
            {
                case 3:
                    words_3.Add(text[i].ToUpper());
                    break;
                case 4:
                    words_4.Add(text[i].ToUpper());
                    break;
                case 5:
                    words_5.Add(text[i].ToUpper());
                    break;
                case 6:
                    words_6.Add(text[i].ToUpper());
                    break;
                case 7:
                    words_7.Add(text[i].ToUpper());
                    break;
                default:
                    Debug.Log("\"" + text[i] + "\" is not allowed");
                    break;
            }
        }
    }

    public static Tile ChartoTile(char A)
    {
        if (char.IsLetter(A))
        {
            return (Tile)((int)(char.ToUpper(A)) - 64);
        }
        else return Tile._;
    }

    public static char TiletoChar(Tile A)
    {
        if(A == Tile._) { return '_'; }
        else if(A == Tile.question_mark) { return '?'; }
        else
        {
            return (char)((int)A + 64);
        }
    }

    public static string TilestoString(Tile[] AAAA)
    {

       char[] str = new char[AAAA.Length];
       for(int i = 0; i< AAAA.Length; i++)
       {
            str[i] = TiletoChar(AAAA[i]);
       }
        return (new string(str));
    }

    //private void Start()
    //{
    //    for (int i = 1; i < 27; i++)
    //    {

    //        Debug.Log("Points for " + TiletoChar((Tile)i) + ": " + points[i]);
    //    }
    //    char[] c = "Helloworld".ToCharArray();
    //    Debug.Log(GetWordValue(c));
    //    Debug.Log(GetWordValue(new string(c)));
    //    Debug.Log(GetWordValue("Helloworld"));
    //}


    public static int GetCharValue(char c)
    {
        return points[(int)ChartoTile(c)];
    }

    public int GetTileValue(Tile tile)
    {
        return points[(int)tile];
    }

    public static int GetWordValue(string s)
    {
        int ret_val = 0;
        for(int i = 0; i < s.Length; i++)
        {
            ret_val += GetCharValue(s[i]);

        }
        return ret_val;
    }

    public static int GetWordValue(char[] c)
    {
        int ret_val = 0;
        for (int i = 0; i < c.Length; i++)
        {
            ret_val += GetCharValue(c[i]);

        }
        return ret_val;
    }

    public static int GetWordValue(Tile[] t)
    {
        string s = TilestoString(t);
        int ret_val = 0;
        for (int i = 0; i < s.Length; i++)
        {
            ret_val += GetCharValue(s[i]);

        }
        return ret_val;
    }


    public void PlaceRandomLetter(Transform place)
    {
        Instantiate(WordHandler.instance.letter_tile_prefab, place.position, Quaternion.identity, Proceed.instance.holder[1]);
    }

    public Tile[] RandomWord(int word_length)
    {
        string word = "Cat";

        switch (word_length)
        {
            case 3:
                word = words_3[Random.Range(0,words_3.Count)];
                break;
            case 4:
                word = words_4[Random.Range(0, words_4.Count)];
                break;
            case 5:
                word = words_5[Random.Range(0, words_5.Count)];
                break;
            case 6:
                word = words_6[Random.Range(0, words_6.Count)];
                break;
            case 7:
                word = words_7[Random.Range(0, words_7.Count)];
                break;
            default:
                Debug.Log("word_length too long, returning CAT instead");
                break;
        }

        Tile[] return_word = new Tile[word.Length];
        for(int i = 0; i < return_word.Length; i++)
        {
            return_word[i] = ChartoTile(word[i]);
        }
        return_word[Random.Range(1, return_word.Length - 2)] = Tile.question_mark;
        return return_word;
    }


    public int EvalWord(Tile[] word)
    {
        switch (word.Length)
        {
            case 3:
                if (words_3.Contains(TilestoString(word))){
                    AudioManagerScript.instance.playTileSound(1);
                    if (GameController.instance.point_style == PointStyle.EntireWord || GameController.instance.point_style == PointStyle.Everything)
                        GameController.instance.total_points += Mathf.FloorToInt(GameController.instance.block_multiplier * GetWordValue(word));
                    return 1;
                }
                else  AudioManagerScript.instance.playTileSound(2);  return -1; 
            case 4:
                if (words_4.Contains(TilestoString(word))) {
                    AudioManagerScript.instance.playTileSound(1);
                    if (GameController.instance.point_style == PointStyle.EntireWord || GameController.instance.point_style == PointStyle.Everything)
                        GameController.instance.total_points += Mathf.FloorToInt(GameController.instance.block_multiplier * GetWordValue(word));
                    return 1;
                }
                else AudioManagerScript.instance.playTileSound(2); return -1;
            case 5:
                if (words_5.Contains(TilestoString(word))) {
                    AudioManagerScript.instance.playTileSound(1);
                    if (GameController.instance.point_style == PointStyle.EntireWord || GameController.instance.point_style == PointStyle.Everything)
                        GameController.instance.total_points += Mathf.FloorToInt(GameController.instance.block_multiplier * GetWordValue(word));
                    return 1;
                }
                else AudioManagerScript.instance.playTileSound(2); return -1;
            case 6:
                if (words_6.Contains(TilestoString(word))) {
                    AudioManagerScript.instance.playTileSound(1);
                    if (GameController.instance.point_style == PointStyle.EntireWord || GameController.instance.point_style == PointStyle.Everything)
                        GameController.instance.total_points += Mathf.FloorToInt(GameController.instance.block_multiplier * GetWordValue(word));
                    return 1;
                }
                else AudioManagerScript.instance.playTileSound(2); return -1;
            case 7:
                if (words_7.Contains(TilestoString(word))) {
                    AudioManagerScript.instance.playTileSound(1);
                    if (GameController.instance.point_style == PointStyle.EntireWord || GameController.instance.point_style == PointStyle.Everything)
                        GameController.instance.total_points += Mathf.FloorToInt(GameController.instance.block_multiplier * GetWordValue(word));
                    return 1;
                }
                else AudioManagerScript.instance.playTileSound(2); return -1;
            default:
                Debug.Log("word_length wrong");
                return -1;
        }
        
    }

}
