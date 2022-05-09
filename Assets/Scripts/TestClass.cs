using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestClass
{
    public class MyPlayer
    {
        private string name;
        private int point;

        public MyPlayer() {}
        public MyPlayer(int mypoint){ point = mypoint; }
        public MyPlayer(string myname, int mypoint) { name = myname; point = mypoint; }

        public string getName(){ return name; }
        public int getPoint(){ return point; }

    }
}
