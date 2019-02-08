using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace WebADMs.Model
{
    public interface IData
    {
        string data { get; set; }
        void Update(string s);
    }
    public class Data
    {

        public Data()
        {
            data = "[{\"name\":\"5XR - KZ\",\"id\":1,\"adms\":[{\"name\":\"asdf\",\"id\":1},{\"name\":\"asdf\",\"id\":1}]},{\"name\":\"75C - WN\",\"id\":2,\"adms\":[{\"name\":\"asdf\",\"id\":1}]},{\"name\":\"BG - W90\",\"id\":3,\"adms\":[]},{\"name\":\"C - 0ND2\",\"id\":4,\"adms\":[]},{\"name\":\"I5Q2 - S\",\"id\":5,\"adms\":[]},{\"name\":\"JI - LGM\",\"id\":6,\"adms\":[]},{\"name\":\"OCU4 - R\",\"id\":7,\"adms\":[]},{\"name\":\"PO - 3QW\",\"id\":8,\"adms\":[]},{\"name\":\"VF - FN6\",\"id\":9,\"adms\":[]},{\"name\":\"Z - PNIA\",\"id\":10,\"adms\":[]}]";
        }
        public  string data { get; set; }

        public void Update(string s)
        {
            data = s;
        }
        
    }
}
