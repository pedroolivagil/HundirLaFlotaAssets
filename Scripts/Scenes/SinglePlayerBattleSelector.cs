using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerBattleSelector : MonoBehaviour{
    public int MockIDUser;
    public Image mapa;

    // Use this for initialization
    void Start(){
        if (MockIDUser > 0){
            testMongo();
        }
    }

    public void testMongo(){
        UserController userCon = MapControllers.GetInstance().UserController;
        User user = new User();
        user.Username = "Insert";
        user.Firstname = "Unity";
        user.Lastname = "MongoDB";
        user.Password = "1234";
        user.Email = "insert@hundirFlota.com";
        user.EmailSecurity = "admin@wergfewr.fe";
        user.Country = "spain";
        user.State = "catalonia";
        user.Birthday = 21;
        user.Gender = 1;
        user.Address = "C/wergerkg 32";

        if (userCon.Create(user)){
            Debug.Log("Usuario creado");
        } else{
            Debug.Log("Usuario NO creado");
        }

        if (userCon.FindById(20) != null){
            Debug.Log("Usuario existe");
        } else{
            Debug.Log("No existe el usuario");
        }
//        if (userCon.Delete(2)){
//            Debug.Log("El usuario ha sido borrado");
//        } else{
//            Debug.Log("El usuario no existe");
//        }
    }
}