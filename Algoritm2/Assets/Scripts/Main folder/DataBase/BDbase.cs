using System;
using UnityEngine;
using System.Collections.Generic;

public class BDbase : IQueryDatabase
{
    public string AddStudent(int idUser)
    {
        try
        {
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            object queryBD = databaseQuery.QueryBD($"add_student('{idUser}')");
            Debug.Log(queryBD);
        }
        catch
        {
            Debug.Log("Ошибка add_student");
        }
        return null;
    }

    public string AddTaskTeacher(int idTeach, string nameTask, string textTask, string algoritmTask)
    {
        try
        {
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            object queryBD = databaseQuery.QueryBD($"add_task_teacher('{idTeach}','{nameTask}','{textTask}','{algoritmTask}')");
            Debug.Log(queryBD);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return null;
    }

    public string AddTeacher(int idUser, string login)
    {
        try
        {
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            object queryBD = databaseQuery.QueryBD($"add_teacher('{idUser}','{login}')");
            Debug.Log(queryBD);
        }
        catch
        {
            Debug.Log("Ошибка add_teacher");
        }
        return null;
    }

    public void AddUser(string login, string password, string role)
    {
        try
        {
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            object queryBD = databaseQuery.QueryBD($"call create_user_db('{login}','{password}','{role}')");
            Debug.Log(queryBD);
        }
        catch
        {
            Debug.Log("Ошибка добавления пользователя BD_base");
        }
    }

    public string EnterApp(string login, string password)
    {
        try
        {
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            object queryBD = databaseQuery.QueryBD($"call enter_app_db('{login}','{password}')");
            Debug.Log(queryBD);
            return queryBD.ToString();
        }
        catch
        {
            Debug.Log("Ошибка получения роли");
        }
        return null;
    }

    public string GetAlgoritmPrac(string nameTask)
    {
        try
        {
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            string query = databaseQuery.StrQuery($"Call get_algoritm_prac('{nameTask}')");
            return query;
        }
        catch
        {
            Debug.Log("Ошибка get_prac_text_task");
        }

        return null;
    }

    public List<string> GetNameTextTeacher(int idTeacher)
    {
        try
        {
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            List<string> query = databaseQuery.ListQuery($"Call get_name_text_teachers({idTeacher})");
            return query;
        }
        catch
        {
            Debug.Log("Ошибка get_name_text_teachers");
        }

        return null;
    }

    public string GetIdTeacher(int idUser)
    {
        try
        {
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            string query = databaseQuery.StrQuery($"Call get_id_teacher('{idUser}')");
            return query;
        }
        catch
        {
            Debug.Log("Ошибка get_id_teacher");
        }
        return null;
    }

    public string DeleteTask(string nameTask)
    {
        try
        {
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            object queryBD = databaseQuery.QueryBD($"delete_task_name('{nameTask}')");
            Debug.Log(queryBD);
        }
        catch
        {
            Debug.Log("Ошибка delete_task_name");
        }
        return null;
    }

    public string GetAmountTaskTeacher(string login)
    {
        try
        {
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            string query = databaseQuery.StrQuery($"Call get_amount_task_teacher('{login}')");
            return query;
        }
        catch
        {
            Debug.Log("Ошибка get_amount_task_teacher");
        }
        return null;
    }

    public string GetAmountTheory(int idUser)
    {
        try
        {
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            string query = databaseQuery.StrQuery($"Call get_amount_theory('{idUser}')");
            return query;
        }
        catch
        {
            Debug.Log("Ошибка get_amount_theory");
        }

        return null;
    }

    public string GetIdTeach(string login)
    {
        try
        {
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            string query = databaseQuery.StrQuery($"Call get_id_teach('{login}')");
            return query;
        }
        catch
        {
            Debug.Log("Ошибка get_id_teach");
        }
        return null;
    }

    public string GetIdUser(string login)
    {
        try
        {
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            string query = databaseQuery.StrQuery($"Call get_id_user('{login}')");
            return query;
        }
        catch
        {
            Debug.Log("Ошибка get_id_user");
        }
        return null;
    }

    public List<string> GetPracTask()
    {
        try
        {
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            List<string> query = databaseQuery.ListQuery($"Call get_prac_name_task()");
            return query;
        }
        catch
        {
            Debug.Log("Ошибка get_prac_task");
        }

        return null;
    }

    public string GetPracTextTask(string nameTask)
    {
        try
        {
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            string query = databaseQuery.StrQuery($"Call get_prac_text_task('{nameTask}')");
            return query;
        }
        catch
        {
            Debug.Log("Ошибка get_prac_text_task");
        }

        return null;
    }

    public List<string> NameTask()
    {
        try
        {
            List<string> _list = new List<string>();
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            _list = databaseQuery.ListQuery("select name_task from select_name_task_text_task_from_task");
            return _list;
        }
        catch
        {
            Debug.Log("Ошибка name task, base");
        }
        return null;
    }

    public string StudentAddAmountTask(int idUser, int amout)
    {
        try
        {
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            object queryBD = databaseQuery.QueryBD($"add_amount_task_student('{idUser}','{amout}')");
            Debug.Log(queryBD);
        }
        catch
        {
            Debug.Log("Ошибка student_add_amount_task");
        }
        return null;
    }

    public List<string> TextTask()
    {
        try
        {
            List<string> _list = new List<string>();
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            _list = databaseQuery.ListQuery("select text_task from select_name_task_text_task_from_task");
            return _list;
        }
        catch
        {
            Debug.Log("Ошибка text task, base");
        }
        return null;
    }

    public List<string> UsersLogin()
    {
        try
        {
            List<string> _list = new List<string>();
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            _list = databaseQuery.ListQuery("select * from select_logins_from_users");
            return _list;
        }
        catch
        {
            Debug.Log("Ошибка list login, base");
        }

        return null;
    }

    public List<string> UsersRole()
    {
        try
        {
            List<string> _list = new List<string>();
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            _list = databaseQuery.ListQuery("select * from select_role_from_users");
            return _list;
        }
        catch
        {
            Debug.Log("Ошибка list role, base");
        }
        return null;
    }
}
