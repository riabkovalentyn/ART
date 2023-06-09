using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ART
{
     class JsonSeralizer
    {
        public static List<Park> DesarilizatorLoadPark()
        {

            List<Park> parks = new List<Park>();

            DataContractJsonSerializer jsonF = new DataContractJsonSerializer(typeof(List<Park>));

            using (FileStream fs = new FileStream("D:\\Server(Emulation)Data.json", FileMode.OpenOrCreate))
            {

                parks = (List<Park>)jsonF.ReadObject(fs);
               
                return parks;

            }
        }
        public static void SeralizatorSavePark(List<Park> parks)

        {

            DataContractJsonSerializer jsonF = new DataContractJsonSerializer(typeof(List<Park>));
            using (FileStream fs = new FileStream("D:\\Server(Emulation)Data.json", FileMode.OpenOrCreate))
            {
                jsonF.WriteObject(fs, parks);
            }


        }
        public static List<User> DesarilizatorLoadUser()
        {

            List<User> users = new List<User>();

            DataContractJsonSerializer jsonF = new DataContractJsonSerializer(typeof(List<User>));

            using (FileStream fs = new FileStream("D:\\Server(Emulation)Data.json", FileMode.OpenOrCreate))
            {
                users = (List<User>)jsonF.ReadObject(fs);
               

                return users;

            }
        }
        public static void SeralizatorSaveUser(List<User> users)

        {

            DataContractJsonSerializer jsonF = new DataContractJsonSerializer(typeof(List<User>));
            using (FileStream fs = new FileStream("D:\\Server(Emulation)Data.json", FileMode.OpenOrCreate))
            {
                jsonF.WriteObject(fs, users);
            }


        }
    }
}
