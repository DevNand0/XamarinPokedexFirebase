using System;
using System.Collections.Generic;
using System.Text;
using MvvmGuia.Model;
using MvvmGuia.Conn;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;

namespace MvvmGuia.Data
{
    public class DataPokemon
    {
        public async Task Insert(Pokemon pokemon) 
        {
            await ConnectDBFirebase.firebase.Child("Pokemon").PostAsync(new Pokemon
            {
                Colorfondo  = pokemon.Colorfondo,
                Icono       = pokemon.Icono,
                Nombre      = pokemon.Nombre,
                Nroorden    = pokemon.Nroorden,
                Poder       = pokemon.Poder,
                ColorPoder  = pokemon.ColorPoder
            });
        }

        public async Task<System.Collections.ObjectModel.ObservableCollection<Pokemon>> MostrarTodos() 
        {
            /*
            //para lista
            var list = await ConnectDBFirebase.firebase.Child("Pokemon")
                                                       .OnceAsync<Pokemon>();
            return list.Select(poke=>new Pokemon() 
            {
                Id = poke.Key,
                Colorfondo = poke.Object.Colorfondo,
                Icono = poke.Object.Icono,
                Nombre = poke.Object.Nombre,
                Nroorden = poke.Object.Nroorden,
                Poder = poke.Object.Poder,
                ColorPoder = poke.Object.ColorPoder
            }).ToList();
            */
            var data = await Task.Run(() =>
                ConnectDBFirebase.firebase
                            .Child("Pokemon")
                            .AsObservable<Pokemon>()
                            .AsObservableCollection()); 
            return data;
        }
    }
}
