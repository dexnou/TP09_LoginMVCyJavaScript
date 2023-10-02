using System.Data.SqlClient; 
using Dapper; 

public class Usuario{
    public int id{get;set;}
    public string UserName{get;set;}
    public string Contraseña{get;set;}
    public string Email{get;set;}
    public int Telefono{get;set;}
    public char Genero{get;set;}

    public Usuario(string userName, string contra, string mail, int tel, char gen){
        UserName = userName;
        Contraseña = contra;
        Email = mail;
        Telefono = tel;
        Genero = gen;
    }
}