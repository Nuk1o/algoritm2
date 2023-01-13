using System.Collections.Generic;
using TMPro;
using UnityEngine;
using core;
using Unity.Mathematics;

public class Admin_panel : MonoBehaviour
{
    [SerializeField] private GameObject _row;
    [SerializeField] private GameObject _parent;
    private Component[] tmp_texts;

    private void Start()
    {
        core.Core _core = new Core();
        
        List<string> _login_users_bd = new List<string>();
        List<string> _role_users_bd = new List<string>();
        
        _login_users_bd = _core.users_admin_panel_login();
        _role_users_bd = _core.users_admin_panel_role();

        int _count_R = _login_users_bd.Count;
        
        
        while (_count_R != 0)
        {
            GameObject _new_row = Instantiate(_row,Vector3.zero, quaternion.identity,_parent.transform);
            tmp_texts = _new_row.GetComponentsInChildren<TMP_Text>();
            _count_R--;
            GameObject _go1 = tmp_texts[0].gameObject;
            GameObject _go2 = tmp_texts[1].gameObject;
            TMP_Text _login = _go1.GetComponent<TMP_Text>();
            TMP_Text _role = _go2.GetComponent<TMP_Text>();
            _login.text = _login_users_bd[_count_R];
            _role.text = _role_users_bd[_count_R];
        }
        DestroyImmediate(_row);
    }
}
