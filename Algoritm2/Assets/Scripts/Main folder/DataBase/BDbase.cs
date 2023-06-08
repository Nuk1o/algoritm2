using System;
using UnityEngine;
using System.Collections.Generic;
/*
 *  Скрипт хранящий в себе все вызовы к бд
 *  A script storing all database calls
 */
public class BDbase : IQueryDatabase
{
    /*
     *  Добавление студента
     *  Adding a student
     */
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
    
    /*
     *  Добавляем определённому студенту значение кол-во решённых задач
     *  Add the number of solved problems to a certain student
     */
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
            Debug.Log("Ошибка add_amount_task_student");
        }
        return null;
    }
    
    /*
     *  Сохраняем практическую задачу, сделанную преподавателем
     *  Save the practical task made by the teacher
     */
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
    
    /*
     *  Добавление преподавателя
     *  Adding a teacher
     */
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
    
    /*
     *  Добавление пользователя
     *  Adding a user
     */
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
    
    /*
     *  Авторизация в приложение
     *  Authorization in the application
     */
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
    
    /*
     *  Получить алгоритм решения задачи по её названию
     *  Get the algorithm for solving the problem by its name
     */
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
    
    /*
     *  Получить название задач сделанным определённым учителем
     *  Get the name of the tasks made by a certain teacher
     */
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
    
    /*
     *  Получить id преподавателя по id пользователя
     *  Get teacher id by user id
     */
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
    
    /*
     *  Удалить задачу с данным названием
     *  Delete a task with this name
     */
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
    
    /*
     *  Получить кол-во просмотренного учебного материала
     *  Get the amount of training material viewed
     */
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
    
    /*
     *  Получить кол-во верно решённых практических работ
     *  Get the number of correctly solved practical works
     */
    public string GetAmountTask(int idUser)
    {
        try
        {
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            string query = databaseQuery.StrQuery($"Call get_amount_task('{idUser}')");
            return query;
        }
        catch
        {
            Debug.Log("Ошибка get_amount_task");
        }
        return null;
    }
    
    /*
     *  Получить id преподавателя по логину
     *  Get teacher id by login
     */
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
    
    /*
     *  Получить id пользователя по логину
     *  Get user id by login
     */
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
    
    /*
     *  Получить список практических задач
     *  Get a list of practical tasks
     */
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
    
    /*
     *  Получить список описания практических задач
     *  Get a list of descriptions of practical tasks
     */
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
    
    /*
     *  Получить список названия задач
     *  Get a list of task names
     */
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
    
    /*
     *  Добавляем определённому студенту значение кол-во просмотренного учебного материала
     *  Add to a certain student the value of the amount of courseware viewed
     */
    public string StudentAddAmountTheory(int idUser, int amout)
    {
        try
        {
            IDatabaseQuery databaseQuery = new DatabaseQuery();
            object queryBD = databaseQuery.QueryBD($"add_amount_theory_student('{idUser}','{amout}')");
            Debug.Log(queryBD);
        }
        catch
        {
            Debug.Log("Ошибка add_amount_theory_student");
        }
        return null;
    }
    
    /*
     *  Получить список пользователей
     *  Get list of users
     */
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
    
    /*
     *  Получить список ролей
     *  Get list of roles
     */
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
