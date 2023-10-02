using System.Data.SqlClient; 
using Dapper; 

public class BD{
    private static string _connectionString = @"Server=.;DataBase=tp09JavaScriptYMVC;Trusted_Connection=True;";

    public static void RegistrarUsuario(Usuario user){
        string sql = "INSERT INTO Usuario(id, UserName, Contraseña, Email, Telefono, Genero) VALUES (@pid, @pUserName, @pContraseña, @pEmail, @pTelefono, @pGenero)"
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new {pid = user.id, pUserName = user.UserName, pContraseña = user.Contraseña, pEmail = user.Email, pTelefono = user.Telefono, pGenero = user.Genero});
        }
    }

    public static List<Usuario> LoginUsuario(){
        List<Usuario> listaUsuarios;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Usuarios";
            listaUsuarios = db.Query<Categoria>(sql).ToList();
        }
        return listaUsuarios;
    }

    

}