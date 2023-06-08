using System.Collections.Generic;

public interface IQueryDatabase
{
    public void AddUser(string login, string password, string role);
    public string EnterApp(string login, string password);
    public List<string> UsersLogin();
    public List<string> UsersRole();
    public List<string> NameTask();
    public string StudentAddAmountTheory(int idUser, int amout);
    public string StudentAddAmountTask(int idUser, int amout);
    public string AddTaskTeacher(int idTeach, string nameTask, string textTask, string algoritmTask);
    public string AddTeacher(int idUser, string login);
    public string AddStudent(int idUser);
    public string GetIdUser(string login);
    public string GetIdTeach(string login);
    public string GetAmountTheory(int idUser);
    public string GetAmountTask(int idUser);
    public List<string> GetPracTask();
    public string GetPracTextTask(string nameTask);
    public string GetAlgoritmPrac(string nameTask);

    public List<string> GetNameTextTeacher(int idTeacher);

    public string GetIdTeacher(int idUser);

    public string DeleteTask(string nameTask);
}