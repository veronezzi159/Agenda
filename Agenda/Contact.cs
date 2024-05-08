using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    internal class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string email { get; set; }

        List<Phone> phones;

        public Contact()
        {
            
        }

        public Contact(string name, string andress, string email, int id)
        {
            phones = new List<Phone>();
            this.Name = name;
            this.Address = andress;
            this.email = email;
            this.Id = id;
            phones.Capacity = 2;
        }

        public override string ToString()
        {
            return "Id: "+Id + ";" +"Nome: "+Name +";" +"Endereço: "+ Address + ";"+"Email: " + email + ";"+"Telefones: " + phones[0] + ";" + phones[1];
        }        
        public void AddPhones(Phone phone)
        {
            if (phones.Count < 3)
            {
                phones.Add(phone);
            }
            else
            {
                Console.WriteLine("Numero maximo de telefones atingidos");
            }
        }
        public void RemovePhones(Phone phone)
        {
            if (phones.Count > 0)
            {
                if (phones.Contains(phone))
                {
                    phones.Remove(phone);
                } else
                    Console.WriteLine("telefone não existente");
            }else
                Console.WriteLine("Este contato ainda não possui um telefone");
        }

        public void PhoneEdit( int n)
        {
            if (phones[n] != null)
            {
                Console.WriteLine("Digite um novo numero de telefone");
                string num = Console.ReadLine();
                phones[n] = new(num);
            }
            else
            {
                Console.WriteLine("telefone não inserido");
            }
        }
        public int CountPhones()
        {
            return phones.Count;
        }

        public void PrintPhones()
        {
            int c = 0;
            foreach (Phone phone in phones)
            {
                c++;
                Console.WriteLine($"{c} - {phone.phoneNumber}");
            }
        }
    }
    
}
