using Agenda;
using System.Runtime.Intrinsics.Arm;

List <Contact> contactsList= new List <Contact> ();
int id_controller = 0;
string path = @"C:\DadosAgenda\", file = "agenda.txt";

int Menu()
{
    int op = 0;
    do
    {
        Console.WriteLine("Informe a opção desejada");

        Console.WriteLine("1 - Cadastrar um contato");
        Console.WriteLine("2 - Cadastrar um numero");
        Console.WriteLine("3 - Deletar um contato");
        Console.WriteLine("4 - Deletar um numero");
        Console.WriteLine("5 - Ver um contato");
        Console.WriteLine("6 - Ver agenda");
        Console.WriteLine("7 - Editar um contato existe");
        Console.WriteLine("0 - Sair");

        op = int.Parse(Console.ReadLine());
        
    } while (op > 7 || op < 0);

    return op;
}


bool CheckIfExist(string p, string f)
{
    if(!Directory.Exists(p))
        Directory.CreateDirectory(p);
    if(!File.Exists(p+f))
        File.Create(p+f);
    return true;
}

void SaveFile(List <Contact> l, string p, string f)
{
    if(CheckIfExist(p, f))
    {
        StreamWriter sw = new StreamWriter(p+f);
        foreach(Contact c in l)
        {
            sw.WriteLine(c.ToString());
        }
        sw.Close();
    }
}

void ContactEdit(List <Contact> l)
{
    ShowAll(l);
    Console.Write("Informe o Id em que deseja fazer alteração: ");
    int id = int.Parse(Console.ReadLine());
    bool ok = false;
    foreach (var item in l)
    {
        if(item.Id == id)
            ok = true;
    }
    if(ok)
    { 
        int op;
        do
        {
            Console.WriteLine("Informe o que deseja alterar: ");
            Console.WriteLine("1 - Nome");
            Console.WriteLine("2 - Endereço");
            Console.WriteLine("3 - Email");
            Console.WriteLine("4 - Telefone 1");
            Console.WriteLine("5 - Telefone 2");
            Console.WriteLine("0 - cancelar ");
            op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    Console.WriteLine("Digite o novo nome:");
                    foreach (var item in l)
                    {
                        
                        if (item.Id == id)
                            item.Name = Console.ReadLine();
                    }
                    break;
                case 2:
                    Console.WriteLine("Digite o novo endereço:");
                    foreach (var item in l)
                    {
                        if (item.Id == id)
                            item.Address = Console.ReadLine();
                    }
                    break;
                case 3:
                    Console.WriteLine("Digite o novo email");
                    foreach (var item in l)
                    {
                        if (item.Id == id)
                            item.email = Console.ReadLine();
                    }
                    break;
                case 4:
                    foreach (var item in l)
                    {
                        if (item.Id == id)
                            item.PhoneEdit(0);
                    }
                    break;
                case 5:
                    foreach (var item in l)
                    {
                        if (item.Id == id)
                            item.PhoneEdit(1);
                    }
                    break;
                case 0:
                    Console.WriteLine("Cancelando operação...");
                    break;
                default:
                    Console.WriteLine("Escolha uma opção valida");
                    break;
            }
        } while (op > 5 || op < 0);
    } else
        Console.WriteLine("id não existe!");

}

void PhoneCreate(List <Contact> l)
{
    foreach (var item in l)
    {
        Console.WriteLine($"Id: {item.Id} Nome: {item.Name}");
    }
    Console.WriteLine("Digite o Id em que deseja adicionar um telefone");
    int id = int.Parse(Console.ReadLine());

    foreach (var item in l)
    {
        if(item.Id == id)
        {
            Console.WriteLine("Digite o numero de telefone que deseja adicionar ");
            string tel = Console.ReadLine();
            item.AddPhones(new(tel));
        }

    }
    
}

void PhoneDelete(List<Contact> l)
{
    foreach (var item in l)
    {
        int c = item.CountPhones();
        if(c > 0)
        Console.WriteLine($"Id: {item.Id} Nome: {item.Name}");
    }
    Console.WriteLine("Digite o Id em que deseja deltar um telefone");
    int id = int.Parse(Console.ReadLine());

    foreach (var item in l)
    {
        if(item.Id == id)
        {
            item.PrintPhones();
        }
    }
    Console.WriteLine("Digite o indice do telefone que deseja excluir");


}

Contact CreateContact()
{
    Console.WriteLine("Digite as informações do contato");
    Console.Write("Informe o nome completo: ");
    string n = Console.ReadLine();

    Console.Write("Informe o email: ");
    string em = Console.ReadLine();

    Console.Write("Informe o endereço: ");
    string andress = Console.ReadLine();

    id_controller += 1;

    return new(n,andress,em,id_controller);

}

Contact? FindContact(List<Contact> l)
{
    Contact? dell = null;
    bool control = false;
    do
    {
        foreach (var item in l)
        {
            Console.WriteLine($"Id: {item.Id} Nome: {item.Name}");
        }
        Console.WriteLine("Digite o Id  que deseja");
        int id = int.Parse(Console.ReadLine());

        foreach (var item in l)
        {
            if (item.Id == id)
            {
                dell = item;
                control = true;
            }
        }
        if (control == false)
        {
            Console.WriteLine("Digite um Id valido");            
        }
    } while (control == false);

    return dell;
}

void AddContactList(List <Contact> contacts)
{
    contacts.Add(CreateContact());
    
}

void RemoveContactList(List <Contact> contacts)
{
    Contact contact = FindContact(contacts);
    contacts.Remove(contact);
}

void ShowAll(List <Contact> l)
{
    int count = 1;
    foreach (var item in l)
    {
        Console.Write("");
        Console.WriteLine(item.ToString());
    }

    Console.WriteLine("Fim da agenda");
}


do
{
    int op = Menu();
    switch (op) 
    {
        case 1:
            AddContactList(contactsList);
            break;
        case 2:
            PhoneCreate(contactsList);
            break;
        case 3:
            RemoveContactList(contactsList);
            break;
        case 4:
            break;
        case 5:
            break;
        case 6:
            break;
        case 7:
            break;
        case 0:
            break;
        default:
            break;
    }




} while (true);
