using System;
using System.Collections;

namespace chemifroeach
{
    class program
    {
        static void Main(string[] args)
        {
            MyList list = new MyList();

            list.Add("Giorgi");
            list.Add("Gega");
            list.Add("tazo");
            list.Add("Tamo");
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add('d');
            list.Add('a');
            list.Add('t');
            list.Add('a');


            foreach (object item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}

   

