using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmGuia.Conn
{
    public class ConnectDBFirebase
    {
        public static FirebaseClient firebase = new FirebaseClient("https://mvvmproyectoguia-default-rtdb.firebaseio.com/");
    }
}
