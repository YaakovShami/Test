using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlignTest.Pet_Folder
{
    class Category
    {
        int id;
        string name;

        public Category(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public override string ToString()
        {
            return "id: " + this.id.ToString() + "\n" + "name: " + this.name;
        }

    }
}
