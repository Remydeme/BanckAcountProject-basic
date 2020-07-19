/**
 Banque 

* client
* compte en banque 

methode :

*   addClient()  : ajoute un client dans la liste 
*  deleteClient() : 
*   creerCompteEnBanque() => Compte 
*   getClient(nom, id) => cleint 
*   creerCompte(Client client, type compte)
*   searchClient(nom, prenom, id)
*  
 */

using System;
using System.Collections.Generic;

namespace Bank_project
{
  

    public class Bank
    {
        private List<Client> _clients = new List<Client>();
        private List<Account> _accounts = new List<Account>();
    

        public void displayClientList()
        {
            if (_clients.Count <= 0)
            {
                Console.WriteLine("Il n'y a aucun client dans cette banque !");
                return;
            }

            for (int i = 0; i < _clients.Count;  i++)
            {
                Console.WriteLine(i.ToString() + "-");
                _clients[i].DisplayUserInfo();
            }
        }
        
        

        public bool DeleteAccount()
        {
            return true;
        }

        public bool AddAccount(Account account)
        {
            // 1- for wich client do you want to add the acccount 
            // search the client wich the search function 
            
            // 2- add the account if we founded the client else display error 
            return true;
        }

        public bool AddClient(Client client)
        {
            return true;
        }

        public bool DeleteClient(string id)
        {
            return true;
        }

        /**
         *  @param : id : user identity card value. You can past the 5 first characters
         * @ return : {int} the position of the user in the array  
         */
        public int _searchClient(string id)
        {
            for (int i = 0; i < _clients.Count; i++)
            {
                if (_clients[i].IdNumber.Contains(id) == true)
                {
                    return i;
                }
            }
            return -1; 
        }
        /**
         *  @param : id : account unique ID. You can past the 5 first characters
         * @ return : {int} the position of the user in the array  
         */
        public int _searchAccount(string id)
        {
            for (int i = 0; i < _accounts.Count; i++)
            {
                if (_accounts[i].Id.ToString().Contains(id))
                {
                    return i;
                }
            }
            return -1; 
        }

        public void _displayMainMenu()
        {
            Console.WriteLine("______________________________ Menu _______________________________");
            Console.WriteLine("1 - Voir mes clients");
            Console.WriteLine("2 - Voir mes comptes");
            Console.WriteLine("3 - Faire une opération sur compte");
            Console.WriteLine("4 - Supprimer un compte");
            Console.WriteLine("5 - Ajouter un compte");
            Console.WriteLine("6 - Ajouter un client");
            Console.WriteLine("7 - Supprimer un client");
            Console.WriteLine("8 - Quitter ");
            Console.WriteLine("___________________________________________________________________");
        }
        
        public void _operationMenu()
        {
            Console.WriteLine("______________________________ Menu d'opération ___________________________");
            Console.WriteLine("1 - Faire un retrait");
            Console.WriteLine("2 - Faire un depôt");
            Console.WriteLine("3 - Faire un transfert ");
            Console.WriteLine("4 - Historique");
            Console.WriteLine("5 - Exit");
            Console.WriteLine("____________________________________________________________________________"); 
        }

        public void _createAccountMenu()
        {
            Console.WriteLine("______________________________ Menu d'opération ___________________________");
            Console.WriteLine("1 - Créer compte épargne");
            Console.WriteLine("2 - Créer compte dépot");
            Console.WriteLine("3 - Quitter");
            Console.WriteLine("____________________________________________________________________________"); 
        }



        public void _makeAnOperationOnAccount()
        {
            if (_accounts.Count <= 0)
            {
                Console.WriteLine("Il n'y a aucun compte de créé");
                return;
            }

            int index = -1;
            string id = "";
            do
            {
                Console.WriteLine("Quel est l'id du compte ? :");
                id = Console.ReadLine();
                Console.WriteLine("Recherche du compte ...");
                index = _searchAccount(id);

                if (index == -1)
                {
                    Console.WriteLine("Aucun compte trouvé identifier par " + id  + " ! Entrez q puis taper entrer pour quitter si vous ne trouver pas.");
                }

                if (id == "q")
                    return;
            } while (index == -1);

            Console.WriteLine("Vous souhaitez faire un opération sur le compte : ");
            _accounts[index].displayInfos();
            Account selectedAccount = _accounts[index];
            _makeOperationOnAccount(selectedAccount);
        }

        public void _createAccount()
        {
            if (_clients.Count <= 0)
            {
                Console.WriteLine("Il n'y a aucun client de créé. Vous ne pouvez pas créer de compte");
                return;
            }
            int index = -1;
            string id = "";
            do
            {
                Console.WriteLine("Quel est l'id de l'utilisateur ? :");
                id = Console.ReadLine();
                Console.WriteLine("Recherche de l'utilisateur...");
                index = _searchClient(id);

                if (index == -1)
                {
                    Console.WriteLine("Aucun utilisateur trouvé ! Entrez q puis taper entrer pour quitter si vous ne trouver pas.");
                }
            } while (index == -1 && id != "q");

            Console.WriteLine("Vous créer un compte pour : ");
            _clients[index].DisplayUserInfo();
            Client selectedClient = _clients[index];
            bool exit = false;
            string choice; 
            while (exit == false)
            {
                Console.WriteLine("Quel type de compte souhaitez vous créer ? : ");
                _createAccountMenu();
                Console.WriteLine("Faites votre choix : ");
                choice = Console.ReadLine();
                switch (choice)
                {
                   case "1":
                       _createEpargneAccount(selectedClient);
                       break;
                   case "2":
                       _createDepositAccount(selectedClient);
                       break;
                   case "3":
                       exit = true;
                       break;
                   default:
                       Console.WriteLine("Aucun choix valide ");
                       break;
                }
                Console.Clear();
            }
        }
        
        
        


        public void _createClient()
        {
            Console.WriteLine("Quel est votre nom :");
            string name = Console.ReadLine();
            Console.WriteLine("Quel est votre prénom :");
            string firstname = Console.ReadLine();
            Console.WriteLine("Quel est votre numéro de carte d'identité : ");
            String id = Console.ReadLine();
            Console.WriteLine("Quel est votre adresse : ");
            String adress = Console.ReadLine();
            
            Client client = new Client(name, firstname, id, adress);
            Console.WriteLine("L'utilisateur suivant a été ajouté : ");
            client.DisplayUserInfo();
            _clients.Add(client);
        }
        
        private void _createEpargneAccount(Client client)
        {
            Console.WriteLine("Entrer le solde:");
            double solde = Convert.ToDouble(Console.ReadLine());
            
            Console.WriteLine("Quel est le taux d'interet : ");
            double rate = Convert.ToDouble(Console.ReadLine());

            Epargne epargne = new Epargne(_accounts.Count + 1, client, solde, rate);
            
            _accounts.Add(epargne);
            client.Account.Add(epargne);
            Console.WriteLine("L'utilisateur suivant a été ajouté : ");
            
        }
        
        private void _createDepositAccount(Client client)
        {
            Console.WriteLine("Entrer le solde:");
            double solde = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Quel est la valeur de decouvert autorisé :");
            double overdraft = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Quel est la limite de retrait : ");
            double maxWithdraw = Convert.ToDouble(Console.ReadLine());

            DepositAccount depositAccount = new DepositAccount(_accounts.Count + 1, client, solde, overdraft, maxWithdraw);
            
            _accounts.Add(depositAccount);
            client.Account.Add(depositAccount);
            Console.WriteLine("Le compte a été ajouté ");
            
        }

        private void _deleteClient()
        {
            if (_clients.Count <= 0)
            {
                Console.WriteLine("Il n'y a aucun client de créé");
                return;
            }
            Console.WriteLine("Quel est l'id de l'utilisateur ");
            string id = Console.ReadLine();
            int index = _searchClient(id);
            if (index == -1)
            {
                Console.WriteLine("Aucun utilisateur n'a été trouvé avec l'id : " + id );
                return;
            }
            _clients.RemoveAt(index);
        }
        
        private void _deleteAcount()
        {
            if (_accounts.Count <= 0)
            {
                Console.WriteLine("Il n'y a aucun compte de créé");
                return;
            }
            Console.WriteLine("Quel est l'id du compte ");
            string id = Console.ReadLine();
            int index = _searchAccount(id);
            if (index == -1)
            {
                Console.WriteLine("Aucun utilisateur n'a été trouvé avec l'id : " + id );
                return;
            }
            Console.WriteLine("Le compte " + _accounts[index].Id.ToString() + " a été supprimé ");
            _accounts.RemoveAt(index);
        }


        public void displayAllAccountOperations(Account account)
        {
            if (account.Operations.Count <= 0)
            {
                Console.WriteLine("Pas d'opérations disponible");
                return;
            }

            for (int i = 0; i < account.Operations.Count; i++)
            {
                Console.WriteLine(i.ToString() + " - ");
                account.Operations[i].DisplayOperation();
            }
        }


        public void _makeOperationOnAccount(Account account)
        {
            string choice = "";
            bool exit = false;
            double montant = 0;
            string motif = "";
            while (exit == false)
            {
                this._operationMenu();
                Console.WriteLine("Que souhaitez vous faire : ");
                choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Entrer le montant : ");
                        montant = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Entrer le libellé : ");
                        motif = Console.ReadLine();
                        account.makeOperation(new Operation(montant, OperationType.Withdraw, 
                            DateTime.Now.ToString(), motif));
                        break;
                    case "2":
                        Console.WriteLine("Entrer le montant : ");
                        montant = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Entrer le libellé : ");
                        motif = Console.ReadLine();
                        account.makeOperation(new Operation(montant, OperationType.Deposit, 
                            DateTime.Now.ToString(), motif));
                        break;
                    case "3":
                        if (_accounts.Count < 2)
                        {
                            Console.WriteLine("Il n'existe qu'un compte. Il est impossible de faire un virement !");
                        }

                        Console.WriteLine("Entrer le montant : ");
                         montant = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Entrer le libellé : ");
                        motif = Console.ReadLine();
                        int receiverIndex = -1;
                        string receiverId = "";
                        do
                        {
                            Console.WriteLine("Vers quel compte ? (Entrez son ID)");
                            receiverId = Console.ReadLine();
                            Console.WriteLine("Recherche du compte ...");
                            receiverIndex = _searchAccount(receiverId);

                            if (receiverIndex == -1)
                            {
                                Console.WriteLine("Aucun compte trouvé identifier par " + receiverId  + " ! Entrez q puis taper entrer pour quitter si vous ne trouver pas.");
                            }
                        } while (receiverIndex == -1 && receiverId  != "q");
                        
                        account.makeOperation(new Operation(montant, OperationType.Transfert, 
                            DateTime.Now.ToString(), motif));

                        Account receiverAccount = _accounts[receiverIndex];
                        
                        receiverAccount.makeOperation(new Operation(montant, OperationType.Deposit,
                            DateTime.Now.ToString(), motif));
                        break;
                    case "4":
                        displayAllAccountOperations(account);
                        break;
                    default:
                        exit = true;
                        break;
                }
            }

            
        }
        // display all account
        private void _displayAllAccount()
        {
            if (_accounts.Count <= 0)
            {
                Console.WriteLine("Il n'y a aucun compte ");
                return;
            }

            for (int i = 0; i < _accounts.Count; i++)
            {
                Console.WriteLine(i.ToString() + " - ");
                _accounts[i].displayInfos();
            }
        }


        // Start run : Start the application 

        public void Start()
        {
            string choice = "";
            bool exit = false;
            while (exit == false)
            {
                _displayMainMenu();
                Console.WriteLine("Que souhaitez vous faire : "); 
                choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        displayClientList();
                        break;
                    case "2":
                        _displayAllAccount();
                        break;
                    case "3":
                        _makeAnOperationOnAccount();
                        break;
                    case "4":
                        _deleteAcount();
                        break;
                    case "5":
                        _createAccount();
                        break;
                    case "6":
                        _createClient();
                        break;
                    case "7" :
                        _deleteClient();
                        break;
                    case "8":
                        exit = true;
                        break;
                    default:
                        exit = true;
                        break;
                }
            }
        }
    }
}

