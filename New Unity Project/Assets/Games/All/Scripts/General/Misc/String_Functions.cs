using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class String_Functions {
    
	public static string String_Replace(string _input_string, int _index, char _character)
    {
        string new_string = "";
        new_string = _input_string.Remove(_index);
        new_string = _input_string.Insert(_index, "" + _character);
        return new_string;
    }

    public static string String_Addition(string _input_string, int _index, char _character)
    {
        string new_string = "";
        new_string = _input_string.Insert(_index, "" + _character);
        return new_string;
    }
}
