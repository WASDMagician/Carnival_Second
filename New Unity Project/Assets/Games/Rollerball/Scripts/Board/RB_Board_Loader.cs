using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RB_Board_Loader : MonoBehaviour {

    RB_Difficulty_Controller difficulty_controller;
    public TextAsset[] level_text_files;
    public GameObject hole_tile, open_tile, blocking_tile, spawn_tile, number_tile, trim_tile, trim_second, tile_parent, answer_hole;
    public float board_scale;
    public float tile_width, tile_height;
    private int trim_count = 1;
	// Use this for initialization
	void Start () {
        if (hole_tile != null && open_tile != null && blocking_tile != null && spawn_tile != null && number_tile != null && trim_tile != null)
        {
            //Get_Width_Height();
        }
        else
        {
            Debug.Log("A tile renderer is missing");
        }
        difficulty_controller = GetComponent<RB_Difficulty_Controller>();
	}

    void Get_Width_Height()
    {
        if (hole_tile != null)
        {
            MeshRenderer renderer = hole_tile.GetComponentInChildren<MeshRenderer>();
            board_scale = 1;
            tile_width = (renderer.bounds.extents.x * 2) * board_scale;
            tile_height = (renderer.bounds.extents.z * 2) * board_scale;
        }
        else
        {
            Debug.Log("RB: Hole tile is not found.");
        }
    }
   
    public void Generate_Board()
    {
        if (difficulty_controller != null)
        {
           // Get_Width_Height();
            Destroy_Board();
            TextAsset asset = level_text_files[difficulty_controller.current_level];
            string[] lines = asset.text.Split("\n"[0]);
            lines = Rotate_Level_Text(lines);
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    GameObject tile = Spawn_Tile(lines[i][j]);
                    if (tile != null)
                    {
                        tile.transform.localScale = tile.transform.localScale * board_scale;
                        tile.transform.SetParent(tile_parent.transform);
                        tile.transform.rotation = tile.transform.parent.rotation;
                        Position_Tile(i, j, tile);
                    }
                }
            }
        }
        else
        {
            Debug.Log("RB: Difficulty controller not found.");
        }
    }    

    //levels have been recorded with incorrect orientation so must be rotated
    //to do this we read the initial level DOWNWARDS instead of across and create a new level based on that
    string[] Rotate_Level_Text(string[] _level_text)
    {
        string[] rotated_level = new string[_level_text[0].Length];
        for(int i = 0; i < rotated_level.Length; i++)
        {
            string test = Get_Rotated_Line(_level_text, i);
            rotated_level[i] = test;
        }
        return rotated_level;
    }
    
    string Get_Rotated_Line(string[] _level_text, int _index)
    {
        string line = "";
        for(int i = 0; i < _level_text.Length; i++)
        {
            for(int j = 0; j < _level_text[i].Length; j++)
            {
                if(j == _index)
                {
                    line += _level_text[i][j];
                }
            }
        }
        return line;
    }

    GameObject Spawn_Trim(int _i, int _j, string[] _lines)
    {
        GameObject trim = null;
        if(_i == 0 || _i == _lines.Length || _j == 0 || _j == _lines[0].Length)
        {
            if (trim_count % 2 == 0)
            {
                Debug.Log("GREEN");
                trim = Instantiate(trim_tile, tile_parent.transform.position, Quaternion.identity) as GameObject;
                trim.transform.rotation = transform.rotation;
                trim_count++;
            }
            else
            {
                Debug.Log("WHITE");
                trim = Instantiate(trim_second, tile_parent.transform.position, Quaternion.identity) as GameObject;
                trim.transform.rotation = transform.rotation;
                trim_count++;
            }
        }
        return trim;
    }

    GameObject Spawn_Tile(char _tile_type)
    {
        GameObject tile = null;
        if(_tile_type == 'o')
        {
            tile = Instantiate(open_tile, tile_parent.transform.position, Quaternion.identity) as GameObject;
        }
        else if(_tile_type == 's')
        {
            tile = Instantiate(spawn_tile, tile_parent.transform.position, Quaternion.identity) as GameObject;
        }
        else if(_tile_type == 'b')
        {
            tile = Instantiate(blocking_tile, tile_parent.transform.position, Quaternion.identity) as GameObject;
        }
        else if(_tile_type == 'h')
        {
            tile = Instantiate(hole_tile, tile_parent.transform.position, Quaternion.identity) as GameObject;
        }
        else if(_tile_type == 'n')
        {
            //tile = Instantiate(number_tile, tile_parent.transform.position, Quaternion.identity) as GameObject;
            Spawn_Tile('o');

        }
        else if(_tile_type == 't')
        {
            if (trim_count % 2 == 0)
            {
                tile = Instantiate(trim_tile, tile_parent.transform.position, Quaternion.identity) as GameObject;
                trim_count++;
            }
            else
            {
                tile = Instantiate(trim_second, tile_parent.transform.position, Quaternion.identity) as GameObject;
                trim_count++;
            }
        }
        else if(_tile_type == 'x')
        {
            tile = Instantiate(answer_hole, tile_parent.transform.position, Quaternion.identity) as GameObject;
        }
        else
        {
            //Debug.Log("RB: Unknown tile type.");
        }
        return tile;
    }

    void Position_Tile(int _row_index, int _column_index, GameObject _object)
    {
        if (_object != null)
        {
            float x = tile_parent.transform.position.x + tile_width * _column_index;
            float z = tile_parent.transform.position.z + tile_height * _row_index;
            _object.transform.position = new Vector3(x, tile_parent.transform.position.y, z);
        }
    }

    void Position_Trim(int _row_index, int _column_index, string[] _lines, GameObject _object)
    {
        float x = 0.0f;
        float z = 0.0f;
        if(_object != null)
        {
            if(_row_index == 0)
            {
                //place above
                z = tile_parent.transform.position.z + tile_height * _row_index - 1;
            }
            else if(_row_index == _lines.Length)
            {
                //place below
                z = tile_parent.transform.position.z + tile_height * _row_index + 1;
            }

            if(_column_index == 0)
            {
                //place left
                x = tile_parent.transform.position.x + tile_width * _row_index - 1;
            }
            else if(_column_index == _lines[0].Length)
            {
                //place right
                x = tile_parent.transform.position.x + tile_width * _row_index + 1;
            }

            _object.transform.position = new Vector3(x, tile_parent.transform.position.y, z);
        }
    }

    public void Destroy_Board()
    {
        foreach(Transform tile in tile_parent.transform)
        {
            Destroy(tile.gameObject);
        }
    }
}
