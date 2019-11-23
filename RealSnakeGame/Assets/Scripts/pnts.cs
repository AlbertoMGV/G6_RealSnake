using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace obj1
{
    public class pnts
    {
        public string fecha;
        public int id;
        public string nombre;
        public int puntuacion;
        public string resource_uri;

        public pnts()
        {

        }
        public void setValues(string n, int p)
        {
            nombre = n;
            puntuacion = p;
        }
        public string info()
        {
            return puntuacion + " Puntos - " + nombre;
        }

    }
}