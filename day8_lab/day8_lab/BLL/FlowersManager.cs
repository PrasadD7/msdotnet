using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BOL;

namespace BLL
{
    public class FlowersManager
    {
        public static List<Flower> getAll()
        {
            List<Flower> flowers = new List<Flower>();

            return FlowerRepository.getAll(); 
        }

        public static Flower get(int id)
        {
            return FlowerRepository.Get(id);
        }

        public static bool add(Flower f)
        {
            return FlowerRepository.Add(f);
        }
    }
}
