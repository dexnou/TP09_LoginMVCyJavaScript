using System.Data.SqlClient; 
using Dapper; 

public class BD{
    private static string _connectionString = @"Server=.;DataBase=tp09JavaScriptYMVC;Trusted_Connection=True;";
    private static Usuario _UserLog = null;

    public static void RegistrarUsuario(Usuario user){
        string sql = "INSERT INTO Usuario(id, UserName, Contraseña, Email, Telefono, Genero) VALUES (@pid, @pUserName, @pContraseña, @pEmail, @pTelefono, @pGenero)";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new {pid = user.id, pUserName = user.UserName, pContraseña = user.Contraseña, pEmail = user.Email, pTelefono = user.Telefono, pGenero = user.Genero});
        }
    }

    public static List<Usuario> LoginUsuario(){
        List<Usuario> listaUsuarios;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Usuario";
            listaUsuarios = db.Query<Usuario>(sql).ToList();
        }
        return listaUsuarios;
    }

    public static Usuario ObtenerUsuario(){
        return _UserLog;
    }

    public static void CrearUsuario(Usuario User)
    {
        int RegistrosAñadidos = 0;
        string sql = "INSERT INTO Usuario(UserName, Contraseña, Email, Telefono, Genero) VALUES (@pName, @pContra, @pMail, @pTel, @pGen)";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            RegistrosAñadidos = db.Execute(sql, new {pName = User.UserName, pContra = User.Contraseña, pMail = User.Email, pTel = User.Telefono, pGen = User.Genero});
        }
        bool esValido = ValidacionUsuario(User.UserName, User.Contraseña);
    }

    public static void ActualizarContraseña(string mailUser, string contra){
        using(SqlConnection db = new SqlConnection(_connectionString)){
            // string sql = "UPDATE Usuario SET Contraseña = @pContra WHERE Email = @pMail";
            string sql = "SELECT * FROM Usuario WHERE Email = @pMail";
            Console.WriteLine("ENTRA UPDATE");
            Usuario usuario = db.QueryFirstOrDefault<Usuario>(sql, new{pMail = mailUser});
        }
    }

    public static bool ValidacionUsuario(string nameUser, string contra)
    {
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Usuario WHERE UserName = @pName and Contraseña = @pContra";
            _UserLog = db.QueryFirstOrDefault<Usuario>(sql, new {pName = nameUser, pContra = contra});
        }
        return(_UserLog != null);
    }

    public static void ContraseñaActualizar(string email, string contraNueva){
        string sql = "UPDATE Usuario SET Contraseña = @pContra where Email = @pMail";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new {pContra = contraNueva, pMail = email});
        }
    }


    public static Usuario VerificacionUsuarioMail(string email)
    {
        Usuario result;
        string sql = "SELECT * FROM Usuario WHERE Email = @pMail";

        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            result = db.QueryFirstOrDefault<Usuario>(sql, new { pMail = email });
        }
        return result;
    }




}