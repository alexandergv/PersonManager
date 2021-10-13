using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace PersonManager.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requerido.*")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo requerido.*")]
        public int Age { get; set; }

        //private static DataTable Added = new DataTable();
        public static List<Person> Added = new List<Person>();

        public static List<Person> Persona(Person person)
        {
            if (Added.Count > 0)
            {
                person.Id = Added.Last().Id + 1;
            }    
            //List<Person> listaP = new List<Person>();
            Added.Add(person);
            return Added;
        }

        public static List<Person> GetOlder()
        {
            List<Person> Oldest = new List<Person>();
            if (Added.Count > 0)
            {
                int m = Added.Max(t => t.Age);
                Oldest = Added.Where(t => t.Age == m).ToList();
            }
                return Oldest;
        }
        public static List<Person> DeleteRow(Person model)
        {
            var IdDel = Added.FindIndex(a => a.Id == model.Id);
            Added.RemoveAt(IdDel);
            return Added;
        }
        public static List<Person> GetCommon()
        {
            List<Person> Common = new List<Person>();
            if (Added.Count > 0)
            {
                var m = Added.GroupBy(t => t.Age).ToList();
                var rep = m.OrderByDescending(grp => grp.Count()).ToList().First().Count();
                var listaRep = m.Where(gr => gr.Count() == rep).ToList();
                var g = listaRep.Select(s => s.Key).ToList();
                //int m = Added.GroupBy(t => t.Age).OrderByDescending(grp => grp.Count())
                //    .Select(grp => grp.Key).First();
                Common = Added.Where(t => g.Contains(t.Age)).OrderBy(gr => gr.Age).ToList();
            }
            return Common;
        }

        public static List<Person> UpdateRecord(Person person)
        {
            var Index = Added.Where(x => true);
            return Added;
        }

    }
}